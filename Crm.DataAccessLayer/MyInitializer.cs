using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.DataAccessLayer
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context) // DB OLUŞTUKTAN SONRA CALISACAK FONKSIYON
        {
            string[] Colors = { "success", "info", "warning", "danger", "primary", "secondary" };
            int ColorsCount = Colors.Count()-1;
            User admin = new User()
            {
                Name = "Emre",
                Surname = "Akdemir",
                Username = "emreakdemir",
                Password = "123456",
                Email = "emre@pusulaplus.com",
                IsActive = true,
                ActivateGuid = Guid.NewGuid(),
                IsAdmin = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "system"
            };

            User standart = new User()
            {
                Name = "Standart",
                Surname = "Kullanıcı",
                Username = "standart",
                Password = "123456",
                Email = "standart@pusulaplus.com",
                IsActive = true,
                ActivateGuid = Guid.NewGuid(),
                IsAdmin = false,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "system"
            };
            context.Users.Add(admin);
            context.Users.Add(standart);
            context.SaveChanges();


            // AUTO-USER CREATİNG
            for (int x = 0; x < 10; x++)
            {
                User autoUser = new User()
                {
                    Name = "ad "+x,
                    Surname = "soyad "+x,
                    Username = "user"+x,
                    Password = "123456",
                    Email = "user"+x+"@pusulaplus.com",
                    IsActive = (x % 2 == 0) ? true : false,
                    ActivateGuid = Guid.NewGuid(),
                    IsAdmin = false,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = (x % 2 == 0) ? admin.Username : standart.Username
                };
                context.Users.Add(autoUser);
                context.SaveChanges();
            }

            // FİRM-TASK-CATEGORY CREATİNG
            for (int i = 0; i < 10; i++)
            {
                int user_id = FakeData.NumberData.GetNumber(1, 12);
                User user = context.Users.Where(x => x.Id == user_id) as User;
                FirmTaskCategory firmTaskCategory = new FirmTaskCategory()
                {
                    Name = "TaskCategory"+ i,
                    Color = FakeData.NumberData.GetNumber(0, ColorsCount).ToString(),
                    Owner = user,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                };
                context.FirmTaskCategories.Add(firmTaskCategory);
                context.SaveChanges();
            }

            // FİRM-NOTE-CATEGORY CREATİNG
            for (int i = 0; i < 10; i++)
            {
                int user_id = FakeData.NumberData.GetNumber(1, 12);
                User user = context.Users.Where(x => x.Id == user_id) as User;
                FirmNoteCategory firmNoteCategory = new FirmNoteCategory()
                {
                    Name = "NoteCategory" + i,
                    Color = FakeData.NumberData.GetNumber(0, ColorsCount).ToString(),
                    Owner = user,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                };
                context.FirmNoteCategories.Add(firmNoteCategory);
                context.SaveChanges();
            }


            for (int i = 0; i < 3; i++)
            {
                // FİRM-CATEGORY CREATİNG
                int FirmCategoryCount = i + 1;
                FirmCategory firmCategory = new FirmCategory()
                {
                    Name = "firmCategory"+ FirmCategoryCount,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                };
                context.FirmCategories.Add(firmCategory);

                // FİRM CREATİNG
                for (int j = 0; j < FakeData.NumberData.GetNumber(5,10); j++)
                {
                    int FirmCount = j + 1;
                    string FirmName = "Firm - " + FakeData.NumberData.GetNumber(1000, 9999);
                    string FirmSlug = "firm-" + FakeData.NumberData.GetNumber(1000, 9999);
                    List<FirmSgkFile> firmSgkFileList = null;
                    List<FirmTask> firmTaskList = null;
                    List<FirmNote> firmNoteList = null;
                    Firm firm = new Firm()
                    {
                        Name = FirmName,
                        Slug = FirmSlug,
                        Title = FakeData.NameData.GetCompanyName(),
                        TaxNumber = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                        TaxOffice = FakeData.PlaceData.GetCounty(),
                        RegisterNumber = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                        Address = FakeData.PlaceData.GetAddress(),
                        FirmCategoryId = firmCategory.Id,
                        FirmCategory = firmCategory,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now.AddMinutes(5),
                        ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                    };
                   

                    // FİRM-SGK-FİLE CREATİNG
                    for (int q = 0; q < FakeData.NumberData.GetNumber(5, 10); q++)
                    {
                        int SgkFileCount = q + 1;
                        string SgkFileName = "Firm - " + FakeData.NumberData.GetNumber(1000, 9999);
                        string SgkFileSlug = "firm-" + FakeData.NumberData.GetNumber(1000, 9999);
                        FirmSgkFile firmSgkFile = new FirmSgkFile()
                        {
                            Name = SgkFileName,
                            Slug = SgkFileSlug,
                            Title = FakeData.NameData.GetCompanyName(),
                            Username = FakeData.NumberData.GetNumber(10000000, 99999999).ToString(),
                            Number = FakeData.NumberData.GetNumber(1, 99999).ToString(),
                            SystemPassword = FakeData.NumberData.GetNumber(10000,99999).ToString(),
                            WorkPlacePassword = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                            RegisterNumber = FakeData.NumberData.GetNumber(10000,99999).ToString(),
                            Branch = FakeData.PlaceData.GetCity(),
                            Address = FakeData.PlaceData.GetAddress(),
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now.AddMinutes(5),
                            ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                        };
                        context.FirmSgkFiles.Add(firmSgkFile);
                        firmSgkFileList.Add(firmSgkFile);

                        // FİRM-SGK-FİLE-USER CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int user_id = FakeData.NumberData.GetNumber(1, 12);
                            User user = context.Users.Where(x => x.Id == user_id) as User;
                            FirmSgkFileUsers firmSgkFileUser = new FirmSgkFileUsers()
                            {
                                FirmSgkFile = firmSgkFile,
                                User = user
                            };
                            context.FirmSgkFileUsers.Add(firmSgkFileUser);
                        }
                    }

                    // FİRM-TASK CREATİNG
                    for (int q = 0; q < FakeData.NumberData.GetNumber(5, 10); q++)
                    {
                        int TaskCount = q + 1;
                        List<FirmTaskUsers> firmTaskUserList = null;
                        List<FirmTaskComments> firmTaskCommentList = null;
                        int task_user_id = FakeData.NumberData.GetNumber(1, 12);
                        User task_user = context.Users.Where(x => x.Id == task_user_id) as User;
                        string TaskTitle = "Task - " + FakeData.NumberData.GetNumber(1000, 9999);
                        FirmTask firmTask = new FirmTask()
                        {
                            Title = TaskTitle,
                            Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1,3)),
                            FirmTaskCategoryId = FakeData.NumberData.GetNumber(1, 10),
                            Firm = firm,
                            Owner = task_user,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now.AddMinutes(5),
                            ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                        };
                        firmTaskList.Add(firmTask);

                        // FİRM-TASK-USER CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int user_id = FakeData.NumberData.GetNumber(1, 12);
                            User user = context.Users.Where(x => x.Id == user_id) as User;
                            FirmTaskUsers firmTaskUsers = new FirmTaskUsers()
                            {
                                FirmTask = firmTask,
                                User = user
                            };
                            context.FirmTaskUser.Add(firmTaskUsers);
                            firmTaskUserList.Add(firmTaskUsers);
                        }
                        firmTask.TaskUsers = firmTaskUserList;


                        // FİRM-TASK-COMMENT CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int user_id = FakeData.NumberData.GetNumber(1, 12);
                            User user = context.Users.Where(x => x.Id == user_id) as User;
                            FirmTaskComments firmTaskComments = new FirmTaskComments()
                            {
                                FirmTask = firmTask,
                                Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3))
                            };
                            context.FirmTaskComments.Add(firmTaskComments);
                            firmTaskCommentList.Add(firmTaskComments);
                        }
                        firmTask.TaskComments = firmTaskCommentList;

                        context.FirmTasks.Add(firmTask);
                    }

                    // FİRM-NOTE CREATİNG
                    for (int q = 0; q < FakeData.NumberData.GetNumber(5, 10); q++)
                    {
                        List<FirmNoteUsers> firmNoteUserList = null;
                        List<FirmNoteComments> firmNoteCommentList = null;
                        int note_user_id = FakeData.NumberData.GetNumber(1, 12);
                        User note_user = context.Users.Where(x => x.Id == note_user_id) as User;
                        FirmNote firmNote = new FirmNote()
                        {
                            Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                            FirmNoteCategoryId = FakeData.NumberData.GetNumber(1, 10),
                            Firm = firm,
                            Owner = note_user,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now.AddMinutes(5),
                            ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                        };
                        
                        firmNoteList.Add(firmNote);

                        // FİRM-TASK-USER CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int user_id = FakeData.NumberData.GetNumber(1, 12);
                            User user = context.Users.Where(x => x.Id == user_id) as User;
                            FirmNoteUsers firmNoteUsers = new FirmNoteUsers()
                            {
                                FirmNote = firmNote,
                                User = user
                            };
                            context.FirmNoteUsers.Add(firmNoteUsers);
                            firmNoteUserList.Add(firmNoteUsers);
                        }
                        firmNote.TaskUsers = firmNoteUserList;

                        // FİRM-NOTE-COMMENT CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int user_id = FakeData.NumberData.GetNumber(1, 12);
                            User user = context.Users.Where(x => x.Id == user_id) as User;
                            FirmNoteComments firmNoteComments = new FirmNoteComments()
                            {
                                FirmNote = firmNote,
                                Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3))
                            };
                            context.FirmNoteComments.Add(firmNoteComments);
                            firmNoteCommentList.Add(firmNoteComments);
                        }
                        firmNote.NoteComments = firmNoteCommentList;


                        context.FirmNotes.Add(firmNote);
                    }

                    context.Firms.Add(firm);
                }
                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
