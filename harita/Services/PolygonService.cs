using harita.Abstract;
using harita.Model;

namespace harita.Services
{
    public class PolygonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PolygonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response<Polygon> AddPolygon(Polygon polygon)
        {
            var response = _unitOfWork.Repository<Polygon>().Add(polygon);
            _unitOfWork.Commit();
            return response;
        }

        public Response<Polygon> GetPolygonById(long id)
        {
            return _unitOfWork.Repository<Polygon>().GetById(id);
        }

        public Response<List<Polygon>> GetAllPolygons()
        {
            return _unitOfWork.Repository<Polygon>().GetAll();
        }

        public Response<Polygon> UpdatePolygon(long id, Polygon polygon)
        {
            var response = _unitOfWork.Repository<Polygon>().Update(id, polygon);
            _unitOfWork.Commit();
            return response;
        }

        public Response<bool> DeletePolygon(long id)
        {
            var response = _unitOfWork.Repository<Polygon>().Delete(id);
            _unitOfWork.Commit();
            return response;
        }
    }
}
