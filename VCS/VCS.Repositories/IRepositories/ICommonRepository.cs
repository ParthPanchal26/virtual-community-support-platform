using VCS.Entities;
using System.Collections.Generic;
using VCS.Entities.Models.CommonModels;

namespace VCS.Repositories.IRepositories {
    public interface ICommonRepository {
        List<DropDownResponseModel> CountryList();

        List<DropDownResponseModel> CityList(int countryId);

        List<DropDownResponseModel> MissionCountryList();

        List<DropDownResponseModel> MissionCityList();

        List<DropDownResponseModel> MissionThemeList();

        List<DropDownResponseModel> MissionSkillList();

        List<DropDownResponseModel> MissionTitleList();

        List<DropDownResponseModel> GetUserSkill(int userId);

        Task<bool> AddUserSkill(UserSkills skills);
    }
}
