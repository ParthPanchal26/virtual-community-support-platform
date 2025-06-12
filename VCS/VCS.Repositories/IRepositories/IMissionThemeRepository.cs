using VCS.Entities.Entities;
using VCS.Entities.Models;

namespace VCS.Repositories.IRepositories {
    public interface IMissionThemeRepository {
        Task<List<MissionThemeViewModel>> GetAllMissionTheme();

        Task<MissionThemeViewModel?> GetMissionThemeById(int missionThemeId);

        Task<bool> AddMissionTheme(MissionTheme missionTheme);

        Task<bool> UpdateMissionTheme(MissionTheme missionTheme);

        Task<bool> DeleteMissionTheme(int missionThemeId);
    }
}
