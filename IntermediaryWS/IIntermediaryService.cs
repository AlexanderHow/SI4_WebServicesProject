using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    [ServiceContract]
    public interface IIntermerdiaryService
    {
        [OperationContract]
        Task<string> GetStations();

        [OperationContract]
        Task<string> GetStations(string city);

        [OperationContract]
        Task<string> GetStation(string idStation, string contractName);

        [OperationContract]
        Task<string> GetNbBikes(string idStation, string contractName);

        [OperationContract]
        Task<string> GetNbBikes(string city);

        [OperationContract]
        Task<string> GetPosition(string idStation, string contractName);

        [OperationContract]
        Task<string> GetPositions(string city);

        [OperationContract]
        Task<string> GetContracts();

        [OperationContract]
        Task<string> GetContract(string contractName);
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "IntermediaryWS.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
