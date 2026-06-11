using TravelAgency.BusinessLogic.Core.Package;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Package;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Functions.Package
{
    public class PackageFlow : PackageAction, IPackage
    {
        public List<PackageDto> GetAllPackages() => ExecuteGetAll();
        public PackageDto GetPackageById(int id) => ExecuteGetById(id);
        public ResponceMsg CreatePackage(PackageDto dto) => ExecuteCreate(dto);
        public ResponceMsg UpdatePackage(PackageDto dto) => ExecuteUpdate(dto);
        public ResponceMsg DeletePackage(int id) => ExecuteDelete(id);
    }
}