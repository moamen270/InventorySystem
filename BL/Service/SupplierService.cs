using BL.Service.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Models.Entities;

namespace BL.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.AddAsync(supplier);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
             _supplierRepository.Update(supplier);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier is null)
                return;
             _supplierRepository.Delete(supplier);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Supplier> GetSupplierWithProductsByIdAsync(int id)
        {
            return await _supplierRepository.GetSupplierWithProductsByIdAsync(id);
        }
    }
}