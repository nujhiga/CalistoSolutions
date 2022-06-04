
using System.Reflection;
using CalistoDbCore.Expressions.Builders;
using CalistoDbCore.Services.Repositories;
using CalistoDbCore.U3FEntities;
using CalistoEnvironment;
using CalistoStandards.Definitions.Structures.Cls;
using CalistoStandards.Definitions.Enumerations;
using CalistoStandards.Definitions.Extensions;
using CalistoStandards.Providers;
using CalistoStandards.Definitions.Models;
using CalistoStandards.Definitions.Factories.Cls;
using CalistoStandards.Definitions.Interfaces.Cls;
using CalistoStandards.Definitions.Interfaces.DbCore.Entities;
using CalistoStandards.Definitions.Interfaces.EdCore.Messages;
using CalistoStandards.Definitions.Models.EdCore.Messages;
using CalistoStandards.Definitions.Attributes;

ClEnvironment clEnvironment = ClEnvironment.Instance;
KeyedDelegator delegator = KeyedDelegator.Instance;
DbRepository repo = new DbRepository();

clEnvironment.InitEdCore();

CampusTarget campus = clEnvironment.Gateway.CreateNewTarget(ClCampus.ULP);

Period[] periods = { new(20221), new(20222) };

int?[] careers = { 85, 69 };



clEnvironment.Gateway.SelectedCampus = campus;

clEnvironment.InitDbCore();

using ClParameter clParam = ClParameterFactory.GetSyncCareers(campus.Source, ClRegularity.Ingress, periods, careers);

var res = await repo.RequestCollAsync<VisAlu, NominalEntity>(clParam);

Dictionary<MessageSign, IClComponent> strct = ClMessageStructFactory.GetMessagesStructs<IClRequest>();

var request = strct.TryGetValue(MessageSign.modificar_usuario_grupo, out IClComponent? component);


switch (component)
{
    case IClContainerBody containerBody:
        { }
        break;

    case IClMemberBody memberBody:
        {

            { }
        }
        break;

    case IClMembersBody membersBody:
        { }
        break;

    case IClNodeBody nodeBody:
        { }
        break;

    case IClNodesBody nodesBody:
        { }
        break;

    case IClNodeMemberBody nodeMemberBody:
        {
            var node = nodeMemberBody.NodeProperty;
            {}
        }

        break;
}



Console.ReadKey();