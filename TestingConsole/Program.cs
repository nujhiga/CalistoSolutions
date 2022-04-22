
using CalistoDbCore.Expressions.Builders;
using CalistoDbCore.Services.Repositories;
using CalistoDbCore.U3FEntities;
using CalistoEnvironment;
using CalistoStandards.Definitions;
using CalistoStandards.Definitions.Attributes;
using CalistoStandards.Definitions.Structures.Cls;
using CalistoStandards.Definitions.Enumerations;
using CalistoStandards.Definitions.Extensions;
using CalistoStandards.Definitions.Factories.Cls;
using CalistoStandards.Definitions.Interfaces.DbCore.Persons;
using CalistoStandards.Definitions.Models.DbCore.Persons;
using CalistoStandards.Definitions.Models.DbCore.Students;
using CalistoStandards.Definitions.Models.DbCore.Users;
using CalistoStandards.Definitions.Models.EdCore.Messages;
using CalistoStandards.Providers;

ClEnvironment clEnvironment = ClEnvironment.Instance;
KeyedDelegator delegator = KeyedDelegator.Instance;
DbRepository repo = new DbRepository();

clEnvironment.InitEdCore();

CampusTarget campus = clEnvironment.Gateway.CreateNewTarget(ClCampus.ULP);

Period[] periods = { new (20221), new (20222) };

int?[] careers = { 85, 69 };



clEnvironment.Gateway.SelectedCampus = campus;

clEnvironment.InitDbCore();

using ClParameter clParam = ClParameterFactory.GetSyncCareers(campus.Source, ClRegularity.Ingress, periods, careers);

var res = await repo.ExecuteRequestAsync<VisAlu>(clParam, ClCacheOptions.Min);

{}

//IPerson per = new Person() { UserID = 123880, FieldName = "per", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per3 = new Person() { UserID = 1233, Password = "123", FieldName = "per3", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per4 = new Person() { UserID = 1234, Password = "123", FieldName = "per4", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per5 = new Person() { UserID = 1235, Password = "123", FieldName = "per5", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per6 = new Person() { UserID = 1236, Password = "123", FieldName = "per6", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per7 = new Person() { UserID = 1237, Password = "123", FieldName = "per7", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per8 = new Person() { UserID = 1238, Password = "123", FieldName = "per8", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per9 = new Person() { UserID = 1239, Password = "123", FieldName = "per9", LastName = "jajajaj", Email = "fff@aaa.com" };
//IPerson per10 = new Person() { UserID = 12310, Password = "123", FieldName = "per10", LastName = "jajajaj", Email = "fff@aaa.com" };

//per.UserGroups = new[] { new UserGroup { Enabled = true, GroupID = 1234, Profile = 'A', IsAdmingGroup = false } };
//per9.UserGroups = new[] { new UserGroup { Enabled = true, GroupID = 12349, Profile = 'A', IsAdmingGroup = false } };
//per10.UserGroups = new[] { new UserGroup { Enabled = true, GroupID = 12340, Profile = 'P', IsAdmingGroup = true } };

//IPerson[] persons = new[] { per, per3, per4, per5, per6, per7, per8, per9, per10 };

//bool addedReq = clEnvironment.EdCore.MessageQueueHandler.EnqueueRequest(MessageSign.asignar_usuario_grupo, persons[0]);
//bool addedResp =  await clEnvironment.EdCore.MessageQueueHandler.RequestResponseEnqueue();


//bool addedReq1 = clEnvironment.EdCore.MessageQueueHandler.EnqueueRequest(MessageSign.asignar_usuario_grupo, persons[1]);
//bool addedResp2 = await clEnvironment.EdCore.MessageQueueHandler.RequestResponseEnqueue();

{ }
//MessageBuilder bb = new(campus);

//var xx = bb.GetMessage(MessageSign.registrar_usuarios, persons, ClElementType.Request);

{ }
//bb.GetRequest(MessageSign.registrar_usuario, per);

//await CalistoEdCore.Services.Factories.RequestFactoryTEST.PostSOAPRequestAsync(ClEnvironment._wsClient);


{ }

Console.ReadKey();