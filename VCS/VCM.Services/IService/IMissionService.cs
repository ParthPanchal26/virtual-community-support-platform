using VCS.Entities;
using VCS.Entities.Models;

namespace VCS.Services.IServices {
    public interface IMissionService {
        Task<List<MissionRequestViewModel>> GetAllMissionAsync();
        Task<MissionRequestViewModel?> GetMissionById(int id);
        Task<bool> AddMission(MissionRequestViewModel model);
        Task<IList<MissionDetailResponseModel>> ClientSideMissionList(int userId);
        Task<IList<MissionDetailResponseModel>> GetAllClientMissions();
        Task<bool> ApplyMission(AddMissionApplicationRequestModel model);
        List<MissionApplication> GetMissionApplicationList();
        Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication);
    }
}
