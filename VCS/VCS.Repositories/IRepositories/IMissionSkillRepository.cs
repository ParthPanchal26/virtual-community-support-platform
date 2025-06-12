using System.Collections.Generic;
using VCS.Entities.Models;

namespace VCS.Repositories.IRepositories {
    public interface IMissionSkillRepository {
        List<MissionSkillResponseModel> GetMissionSkillList();

        MissionSkillResponseModel GetMissionSkillById(int id);

        string AddMissionSkill(AddMissionSkillRequestModel model);

        string UpdateMissionSkill(UpdateMissionSkillRequestModel model);

        string DeleteMissionSkill(int id);

        string GetMissionSkills(string skillIds);
    }
}
