using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Services.Repositories;
using CalistoEnvironment;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Structures;


ClEnvironment clEnvironment = ClEnvironment.Instance;

clEnvironment.InitEdCore();

CampusTarget campus = clEnvironment.Gateway.CreateNewTarget(ClCampus.U3F);

clEnvironment.Gateway.CurrentCampus = campus;


var repo = new CalistoDbCore.Services.Repositories.DbRepository(campus, new Period[] {new(20221)});

await repo.ExecuteRequestAsync(RequestAction.SyncCareerStudents, SelectionDepth.Simple, ExecutionOptions.NoCache);

{}


//IPerson per = new Person() { UserID = 123880, Name = "per", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per3 = new Person() { UserID = 1233, Password = "123", Name = "per3", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per4 = new Person() { UserID = 1234, Password = "123", Name = "per4", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per5 = new Person() { UserID = 1235, Password = "123", Name = "per5", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per6 = new Person() { UserID = 1236, Password = "123", Name = "per6", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per7 = new Person() { UserID = 1237, Password = "123", Name = "per7", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per8 = new Person() { UserID = 1238, Password = "123", Name = "per8", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per9 = new Person() { UserID = 1239, Password = "123", Name = "per9", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per10 = new Person() { UserID = 12310, Password = "123", Name = "per10", LastName = "jajajaj", Email = "fff@aaa.com" };

//per.UserGroups = new[] { new UserGroup { Enabled = true, GroupID = 1234, Profile = 'A', IsAdmingGroup = false } };
//per9.UserGroups = new[] { new UserGroup { Enabled = true, GroupID = 12349, Profile = 'A', IsAdmingGroup = false } };
//per10.UserGroups = new[] { new UserGroup { Enabled = true, GroupID = 12340, Profile = 'P', IsAdmingGroup = true } };

//IPerson[] persons = new[] { per, per3, per4, per5, per6, per7, per8, per9, per10 };

//bool addedReq = clEnvironment.EdCore.MessageQueueHandler.EnqueueRequest(MessageSign.asignar_usuario_grupo, persons[0]);
//bool addedResp =  await clEnvironment.EdCore.MessageQueueHandler.RequestResponseEnqueue();


//bool addedReq1 = clEnvironment.EdCore.MessageQueueHandler.EnqueueRequest(MessageSign.asignar_usuario_grupo, persons[1]);
//bool addedResp2 = await clEnvironment.EdCore.MessageQueueHandler.RequestResponseEnqueue();

{}
//MessageBuilder bb = new(campus);

//var xx = bb.GetMessage(MessageSign.registrar_usuarios, persons, ElementType.Request);

{ }
//bb.GetRequest(MessageSign.registrar_usuario, per);

//await CalistoEdCore.Services.Factories.RequestFactoryTEST.PostSOAPRequestAsync(ClEnvironment._wsClient);


{ }

Console.ReadKey();