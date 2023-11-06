using PhotoGallery_BackEnd.DTOs.Users;
using ServiceStack;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhotoGallery_BackEnd.Services.Gallery
{
    public class Gallery : IGallery
    {
        private readonly string uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backup");
        private readonly APIDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Gallery(APIDbContext context, IConfiguration configuration, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<string>> UploadPhoto(PhotoDTO request)
        {
            var response = new ServiceResponse<string>();
            if (request == null)
            {
                response.Data = "Upload fail.";
                response.Success = false;
                response.Message = "No Data was provided.";
                return response;
            }
            try
            {

                var username = request.requestUsername;
                var user = await _context.users
                                        .Include(u => u.userAccessLevels)
                                        .FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));

                #region createTask
                // Generate a unique folder name based on timestamp and task id
                var folderName = request.requestFileName;//GenerateTaskid(true);
                var userDirectory = Path.Combine(uploadFolder);
                // Define Task id
                var taskid = GenerateTaskid(true);
                // Create the directory if it doesn't exist
                Directory.CreateDirectory(userDirectory);
                // Process the file Data
                var fileData = request.requestFile;
                var uploadedFileNames = new List<string>();
                var uploadedFileSystemNames = new List<string>();
                var uploadedFileExtension = new List<string>();
                var uploadedFileSizes = new List<string>();
                var uploadedTableNames = new List<string>();

                if (fileData != null)
                {
                    var file = (fileData);
                    if (file != null)
                    {
                        // Get the original file name
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        // Extract the file extension
                        uploadedFileExtension.Add(Path.GetExtension(fileName));
                        // Generate a unique folder name by appending a counter if the folder already exists
                        var systemfileName = GenerateUniqueFileName(username,request.requestFileName+ uploadedFileExtension[0], userDirectory);
                        var filePath = Path.Combine(userDirectory, systemfileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        fileName = request.requestFileName;
                        uploadedFileNames.Add(fileName);
                        uploadedFileSystemNames.Add(systemfileName);
                        uploadedFileSizes.Add(file.Length.ToString());
                    }
                    else
                    {
                        uploadedFileNames.Add(null);
                        uploadedFileSystemNames.Add(null);
                        uploadedFileSizes.Add(null);
                    }
                }

                // Process the upload setting Data
                // Write Data to a text file
                var textFilePath = Path.Combine(userDirectory, "00_command_logs.txt");
                WriteDataToFile(taskid, uploadedFileNames, uploadedFileSystemNames, uploadedTableNames, textFilePath);

                // Store Data
                var SQL_SectionUploadPathData = new SectionUploadPathData
                {
                    basePath = userDirectory,
                    nameFile = uploadedFileNames[0].ToString(),
                    nameFileSystem = uploadedFileSystemNames[0].ToString(),
                    fileExtension = uploadedFileExtension[0].ToString(),
                    sizeFile = uploadedFileSizes[0].ToString(),
                    timeUpdated = DateTime.UtcNow
                };
                // photo
/*                for (int i = 0; i < uploadedFileNames.Count; i++)
                {
                    var basePathProperty = typeof(SectionUploadPathData).GetProperty($"basePath{i + 1}");
                    basePathProperty.SetValue(SQL_SectionUploadPathData, uploadedFileNames[i]);
                    var fileNameProperty = typeof(SectionUploadPathData).GetProperty($"nameFile{i + 1}");
                    fileNameProperty.SetValue(SQL_SectionUploadPathData, uploadedFileNames[i]);
                    var fileNameProperty = typeof(SectionUploadPathData).GetProperty($"nameFile{i + 1}");
                    fileNameProperty.SetValue(SQL_SectionUploadPathData, uploadedFileNames[i]);
                    var fileSizeProperty = typeof(SectionUploadPathData).GetProperty($"sizeFile{i + 1}");
                    fileSizeProperty.SetValue(SQL_SectionUploadPathData, uploadedFileSizes[i]);
                }*/

                // Create an instance of SectionConvertSettingData
                var SQL_taskModel = new TaskModel
                {
                    taskid = taskid,
                    owner = username,
                    dateCreated = DateTime.Now,
                    status = Models.Tasks.TaskStatus.InQueue,
                    uploadPathData = SQL_SectionUploadPathData,
                };

                // Create an instance of TaskOrderData
                var SQL_TaskOrderData = new TaskOrderData
                {
                    sectionUploadPathData = SQL_SectionUploadPathData,
                };

                #endregion createTask
                // Save the convert setting Data to the Database using your Data access mechanism (e.g., Entity Framework Core)
                _context.sectionUploadPathData.Add(SQL_SectionUploadPathData);
                _context.taskModels.Add(SQL_taskModel);
                _context.taskOrderData.Add(SQL_TaskOrderData);
                await _context.SaveChangesAsync();

                var userDTO = await CheckUser(username);
                response.Data = taskid;
                response.User = userDTO.User;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.User = new UserDto();
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<List<PhotoDTO>>> GetPhotoAll()
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<List<PhotoDTO>>> GetPhotoFilter(string photoName)
        {
            throw new NotImplementedException();
        }
        private string GenerateTaskid(bool isNormal)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var randomNumber = new Random().Next(1000, 9999); // Generate a random 4-digit number

            string taskName = "";
            if (isNormal)
            {
                taskName = $"T_{timestamp}_{randomNumber}";
            }
            else
            {
                taskName = $"T_SC_{timestamp}_{randomNumber}";
            }
            return taskName;
        }
        private string GenerateUniqueFileName(string username,string originalFileName, string directoryPath)
        {
            var fileExtension = Path.GetExtension(originalFileName);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);

            // Maximum allowed file name length
            var maxFileNameLength = 255 - fileExtension.Length;

            if (maxFileNameLength <= 0)
            {
                throw new Exception("The provided directory path is too long.");
            }
            int counter = 1;

            string uniqueFileName = $"{counter}_{username}_{fileNameWithoutExtension}{fileExtension}";

            if (File.Exists(Path.Combine(directoryPath, uniqueFileName)))
            {
                while (File.Exists(Path.Combine(directoryPath, uniqueFileName)))
                {
                    uniqueFileName = $"{counter}_{username}_{fileNameWithoutExtension}{fileExtension}";
                    counter++;
                    if (uniqueFileName.Length > maxFileNameLength)
                    {
                        fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, maxFileNameLength - counter.ToString().Length);
                        uniqueFileName = $"{fileNameWithoutExtension}_{counter}{fileExtension}";
                    }
                    if (uniqueFileName.Length > maxFileNameLength)
                    {
                        throw new Exception("The file name cannot be adjusted to fit within the length limit.");
                    }
                }
            }

            return uniqueFileName;
        }
        private void WriteDataToFile(string taskid, List<string> uploadedFilename, List<string> uploadedSystemFilename, List<string> uploadedTablename, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Task id: {taskid}");
                writer.WriteLine("----------");
                writer.WriteLine("Uploaded File name:");
                int index_file = 1;
                foreach (var filename in uploadedFilename)
                {
                    if (filename == null)
                    {
                        writer.WriteLine(index_file + " : " + "-");
                    }
                    else
                    {
                        writer.WriteLine(index_file + " : " + filename);
                    }
                    index_file++;
                }
                foreach (var filename in uploadedSystemFilename)
                {
                    if (filename == null)
                    {
                        writer.WriteLine(index_file + " : " + "-");
                    }
                    else
                    {
                        writer.WriteLine(index_file + " : " + filename);
                    }
                    index_file++;
                }
                writer.WriteLine("----------");
            }
        }
        public async Task<ServiceResponse<bool>> CheckUser(string username)
        {
            var response = new ServiceResponse<bool>();
            var user = await _context.users
                .Include(u => u.userAccessLevels)
                .FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));

            if (user is null)
            {
                response.Data = false;
                response.User = new UserDto();
                response.Success = false;
                response.Message = "User not found.";
            }
            else
            {
                // The session is still valid
                response.Data = true;
                response.User = new UserDto
                {
                    username = user.username,
                    userAccessLevelid = user.userAccessLevelid,
                    roles = user.userAccessLevels.accessLevelName.ToString()
                };
            }
            return response;
        }
    }
}
