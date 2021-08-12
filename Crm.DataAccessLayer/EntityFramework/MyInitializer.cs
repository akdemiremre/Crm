using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.DataAccessLayer.EntityFramework
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
                    Name = "ad " + x,
                    Surname = "soyad " + x,
                    Username = "user" + x,
                    Password = "123456",
                    Email = "user" + x + "@pusulaplus.com",
                    IsActive = (x % 2 == 0) ? true : false,
                    ActivateGuid = Guid.NewGuid(),
                    IsAdmin = false,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = (x % 2 == 0) ? admin.Username : standart.Username
                };
                context.Users.Add(autoUser);
            }
            context.SaveChanges();

            // FİRM-TASK-CATEGORY CREATİNG
            for (int i = 0; i < 10; i++)
            {
                int firm_task_category_user_id = FakeData.NumberData.GetNumber(1, 12);
                User FirmTaskCategoryOwner = context.Users.Where(x => x.Id == firm_task_category_user_id).FirstOrDefault();
                FirmTaskCategory firmTaskCategory = new FirmTaskCategory()
                {
                    Name = "TaskCategory" + i,
                    Color = FakeData.NumberData.GetNumber(0, ColorsCount).ToString(),
                    Owner = FirmTaskCategoryOwner,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                };
                context.FirmTaskCategories.Add(firmTaskCategory);
            }
            context.SaveChanges();

            // FİRM-NOTE-CATEGORY CREATİNG
            for (int i = 0; i < 10; i++)
            {
                int user_id = FakeData.NumberData.GetNumber(1, 12);
                User user = context.Users.Where(x => x.Id == user_id).FirstOrDefault();
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
            }
            context.SaveChanges();

            for (int i = 0; i < 3; i++)
            {
                // FİRM-CATEGORY CREATİNG
                int FirmCategoryCount = i + 1;
                FirmCategory firmCategory = new FirmCategory()
                {
                    Name = "firmCategory" + FirmCategoryCount,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                };
                context.FirmCategories.Add(firmCategory);

                // FİRM CREATİNG
                for (int j = 0; j < FakeData.NumberData.GetNumber(5, 10); j++)
                {
                    int FirmCount = j + 1;
                    string FirmName = "Firm - " + FakeData.NumberData.GetNumber(1000, 9999);
                    string FirmSlug = "firm-" + FakeData.NumberData.GetNumber(1000, 9999);
                    List<FirmNote> firmNoteList = new List<FirmNote>();
                    List<FirmTask> firmTaskList = new List<FirmTask>();
                    List<FirmSgkFile> firmSgkFileList = new List<FirmSgkFile>();
                    int random_firm_owner_id = FakeData.NumberData.GetNumber(1, 12);
                    User FirmOwner = context.Users.Where(x => x.Id == random_firm_owner_id).FirstOrDefault();
                    Firm firm = new Firm()
                    {
                        Slug = FirmSlug,
                        Name = FirmName,
                        Title = FakeData.NameData.GetCompanyName(),
                        TaxNumber = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                        TaxOffice = FakeData.PlaceData.GetCounty(),
                        RegisterNumber = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                        Address = FakeData.PlaceData.GetAddress(),
                        FirmCategoryId = firmCategory.Id,
                        FirmCategory = firmCategory,
                        Owner = FirmOwner,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now.AddMinutes(5),
                        ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                    };

                    // FİRM-SGK-FİLE CREATİNG
                    for (int q = 0; q < FakeData.NumberData.GetNumber(5, 10); q++)
                    {
                        int SgkFileCount = q + 1;
                        int random_sgk_file_owner_id = FakeData.NumberData.GetNumber(1, 12);
                        User SgkFileOwner = context.Users.Where(x => x.Id == random_sgk_file_owner_id).FirstOrDefault();
                        string SgkFileName = "Firm - " + FakeData.NumberData.GetNumber(1000, 9999);
                        string SgkFileSlug = "firm-" + FakeData.NumberData.GetNumber(1000, 9999);
                        List<FirmSgkFileUsers> firmSgkFileUsersList = new List<FirmSgkFileUsers>();
                        FirmSgkFile firmSgkFile = new FirmSgkFile()
                        {
                            Slug = SgkFileSlug,
                            Name = SgkFileName,
                            Username = FakeData.NumberData.GetNumber(10000000, 99999999).ToString(),
                            Number = FakeData.NumberData.GetNumber(1, 99999).ToString(),
                            SystemPassword = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                            WorkPlacePassword = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                            RegisterNumber = FakeData.NumberData.GetNumber(10000, 99999).ToString(),
                            Branch = FakeData.PlaceData.GetCity(),
                            Title = FakeData.NameData.GetCompanyName(),
                            Address = FakeData.PlaceData.GetAddress(),
                            FirmId = firm.Id,
                            Firm = firm,
                            Owner = SgkFileOwner,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now.AddMinutes(5),
                            ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                        };

                        // FİRM-SGK-FİLE-USER CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int random_sgk_file_user_id = FakeData.NumberData.GetNumber(1, 12);
                            User user = context.Users.Where(x => x.Id == random_sgk_file_user_id).FirstOrDefault();
                            FirmSgkFileUsers firmSgkFileUser = new FirmSgkFileUsers()
                            {
                                FirmSgkFile = firmSgkFile,
                                User = user
                            };
                            context.FirmSgkFileUsers.Add(firmSgkFileUser);
                            firmSgkFileUsersList.Add(firmSgkFileUser);
                        }
                        firmSgkFile.TaskUsers = firmSgkFileUsersList;
                        context.FirmSgkFiles.Add(firmSgkFile);
                        firmSgkFileList.Add(firmSgkFile);
                    }


                    //FİRM - TASK CREATİNG
                    for (int q = 0; q < FakeData.NumberData.GetNumber(5, 10); q++)
                    {
                        int TaskCount = q + 1;
                        List<FirmTaskUsers> firmTaskUserList = new List<FirmTaskUsers>();
                        List<FirmTaskComments> firmTaskCommentList = new List<FirmTaskComments>();
                        int random_task_user_id = FakeData.NumberData.GetNumber(1, 12);
                        User taskUser = context.Users.Where(x => x.Id == random_task_user_id).FirstOrDefault();
                        string TaskTitle = "Task - " + FakeData.NumberData.GetNumber(1000, 9999);
                        int random_firm_task_category_id = FakeData.NumberData.GetNumber(1, 10);
                        FirmTaskCategory firmTaskCategory = context.FirmTaskCategories.Where(x => x.Id == random_firm_task_category_id).FirstOrDefault();
                        FirmTask firmTask = new FirmTask()
                        {
                            Title = TaskTitle,
                            Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                            FirmTaskCategoryId = random_firm_task_category_id,
                            FirmTaskCategory = firmTaskCategory,
                            FirmId = firm.Id,
                            Firm = firm,
                            Owner = taskUser,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now.AddMinutes(5),
                            ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                        };

                        // FİRM-TASK-USER CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int random_firm_task_user_id = FakeData.NumberData.GetNumber(1, 12);
                            User firm_task_user = context.Users.Where(x => x.Id == random_firm_task_user_id).FirstOrDefault();
                            FirmTaskUsers firmTaskUsers = new FirmTaskUsers()
                            {
                                FirmTask = firmTask,
                                User = firm_task_user
                            };
                            context.FirmTaskUser.Add(firmTaskUsers);
                            firmTaskUserList.Add(firmTaskUsers);
                        }
                        firmTask.TaskUsers = firmTaskUserList;

                        // FİRM-TASK-COMMENT CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int random_firm_task_comment_user_id = FakeData.NumberData.GetNumber(1, 12);
                            User firmTaskCommentUser = context.Users.Where(x => x.Id == random_firm_task_comment_user_id).FirstOrDefault();
                            FirmTaskComments firmTaskComments = new FirmTaskComments()
                            {
                                FirmTask = firmTask,
                                Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                                Owner = firmTaskCommentUser,
                                CreatedOn = DateTime.Now,
                                UpdatedOn = DateTime.Now.AddMinutes(5),
                                ModifiedUsername = (w % 2 == 0) ? admin.Username : standart.Username
                            };
                            context.FirmTaskComments.Add(firmTaskComments);
                            firmTaskCommentList.Add(firmTaskComments);
                        }
                        firmTask.TaskComments = firmTaskCommentList;

                        context.FirmTasks.Add(firmTask);
                        firmTaskList.Add(firmTask);
                    }
                    firm.FirmTasks = firmTaskList;

                    // FİRM-NOTE CREATİNG
                    for (int q = 0; q < FakeData.NumberData.GetNumber(5, 10); q++)
                    {
                        List<FirmNoteUsers> firmNoteUserList = new List<FirmNoteUsers>();
                        List<FirmNoteComments> firmNoteCommentList = new List<FirmNoteComments>();
                        int random_firm_note_user_id = FakeData.NumberData.GetNumber(1, 12);
                        User firmNoteUser = context.Users.Where(x => x.Id == random_firm_note_user_id).FirstOrDefault();
                        int random_firm_note_category_id = FakeData.NumberData.GetNumber(1, 10);
                        FirmNoteCategory firmNoteCategory = context.FirmNoteCategories.Where(x => x.Id == random_firm_note_category_id).FirstOrDefault();
                        FirmNote firmNote = new FirmNote()
                        {
                            Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                            FirmNoteCategoryId = random_firm_note_category_id,
                            FirmNoteCategory = firmNoteCategory,
                            Firm = firm,
                            Owner = firmNoteUser,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now.AddMinutes(5),
                            ModifiedUsername = (i % 2 == 0) ? admin.Username : standart.Username
                        };

                        // FİRM-NOTE-USER CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int random_firm_note_list_user_id = FakeData.NumberData.GetNumber(1, 12);
                            User firmNoteListUser = context.Users.Where(x => x.Id == random_firm_note_list_user_id).FirstOrDefault();
                            FirmNoteUsers firmNoteUsers = new FirmNoteUsers()
                            {
                                FirmNote = firmNote,
                                User = firmNoteListUser
                            };
                            context.FirmNoteUsers.Add(firmNoteUsers);
                            firmNoteUserList.Add(firmNoteUsers);
                        }
                        firmNote.TaskUsers = firmNoteUserList;

                        // FİRM-NOTE-COMMENT CREATİNG
                        for (int w = 0; w < FakeData.NumberData.GetNumber(1, 3); w++)
                        {
                            int random_firm_note_comment_user_id = FakeData.NumberData.GetNumber(1, 12);
                            User firmNoteCommentUser = context.Users.Where(x => x.Id == random_firm_note_comment_user_id).FirstOrDefault();
                            FirmNoteComments firmNoteComments = new FirmNoteComments()
                            {
                                FirmNote = firmNote,
                                Description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                                Owner = firmNoteCommentUser,
                                CreatedOn = DateTime.Now,
                                UpdatedOn = DateTime.Now.AddMinutes(5),
                                ModifiedUsername = (w % 2 == 0) ? admin.Username : standart.Username
                            };
                            context.FirmNoteComments.Add(firmNoteComments);
                            firmNoteCommentList.Add(firmNoteComments);
                        }
                        firmNote.NoteComments = firmNoteCommentList;


                        context.FirmNotes.Add(firmNote);
                        firmNoteList.Add(firmNote);
                    }
                    firm.FirmNotes = firmNoteList;

                    context.Firms.Add(firm);
                }
            }
            context.SaveChanges();
        }
    }
}
