using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.App.JwtToken.Services;
using NoteApp.Module.Hostel.Request;
using NoteApp.Module.Hostel.Response;
using System.Collections.Generic;
using System.Linq;
using DbHostel = NoteApp.App.Database.Data.Hostel;

namespace NoteApp.Module.Hostels.Service
{
    public interface IHostelService
    {
        List<HostelResponse> GetList(HostelRequest request);
        bool Add(HostelRequest requset);
        HostelResponse Get(int Id);
    }

    public class HostelService : IHostelService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly noteappContext _noteappContext;

        public HostelService(UnitOfWork unitOfWork, IJwtService jwt, noteappContext noteappContext)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwt;
            _noteappContext = noteappContext;
        }

        public List<HostelResponse> GetList(HostelRequest request)
        {
            var response = new List<HostelResponse>();
            var hostelsQuery = _noteappContext.Hostels;
            if(request.Address != null)
            {
                hostelsQuery.Where(x => x.Address!.Contains(request.Address));
            }
            if (request.OwnerName != null)
            {
                hostelsQuery.Where(x => x.OwnerName!.Contains(request.OwnerName));
            }
            if (request.GoogleMapAddress != null)
            {
                hostelsQuery.Where(x => x.GoogleMapAddress!.Contains(request.GoogleMapAddress));
            }
            if (request.PhoneNumber != null)
            {
                hostelsQuery.Where(x => x.PhoneNumber!.Contains(request.PhoneNumber));
            }
            if (request.PhoneNumber != null)
            {
                hostelsQuery.Where(x => x.ExistenceTime == (request.ExistenceTime));
            }

            var hostels = hostelsQuery.ToList();

            if (hostels != null)
            {
                foreach ( var hostel in hostels)
                {
                    HostelResponse item = new HostelResponse{

                        Id = hostel.Id,
                        Address = hostel.Address,
                        ExistenceTime = hostel.ExistenceTime,
                        GoogleMapAddress = hostel.GoogleMapAddress,
                        PhoneNumber = hostel.PhoneNumber,
                        OwnerName = hostel.OwnerName
                    };
                    response.Add(item);
                }
            }
            return response;
        }

        public bool Add(HostelRequest request)
        {
            try
            {
                DbHostel hostel = new DbHostel
                {
                    Id = 0,
                    Address = request.Address,
                    ExistenceTime = request.ExistenceTime,
                    GoogleMapAddress = request.GoogleMapAddress,
                    OwnerName= request.OwnerName,
                    PhoneNumber = request.PhoneNumber
              
                };
                _noteappContext.Add(hostel);
                _noteappContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public HostelResponse Get(int id)
        {
            var response = new HostelResponse();
            var hostel = _noteappContext.Hostels.FirstOrDefault(x => x.Id == id);
            if (hostel != null)
            {
                response.Id = hostel.Id;
                response.Address = hostel.Address;
                response.GoogleMapAddress = hostel.GoogleMapAddress;
                response.PhoneNumber = hostel.PhoneNumber;
                response.ExistenceTime = hostel.ExistenceTime;
            }
            return response;
        }
    }
}
