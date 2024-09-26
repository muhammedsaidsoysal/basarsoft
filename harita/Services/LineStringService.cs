using harita.Abstract;
using harita.Model;

namespace harita.Services
{
    public class LineStringService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LineStringService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response<LineString> AddLineString(LineString lineString)
        {
            var response = _unitOfWork.Repository<LineString>().Add(lineString);
            _unitOfWork.Commit();
            return response;
        }

        public Response<LineString> GetLineStringById(long id)
        {
            return _unitOfWork.Repository<LineString>().GetById(id);
        }

        public Response<List<LineString>> GetAllLineStrings()
        {
            return _unitOfWork.Repository<LineString>().GetAll();
        }

        public Response<LineString> UpdateLineString(long id, LineString lineString)
        {
            var response = _unitOfWork.Repository<LineString>().Update(id, lineString);
            _unitOfWork.Commit();
            return response;
        }

        public Response<bool> DeleteLineString(long id)
        {
            var response = _unitOfWork.Repository<LineString>().Delete(id);
            _unitOfWork.Commit();
            return response;
        }
    }
}
