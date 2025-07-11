﻿
using VCS.Entities.Models;
using VCS.Repositories.IRepositories;
using VCS.Services.IServices;
using VCS.Entities;

namespace VCS.Services.Services {
    public class MissionService(IMissionRepository missionRepository, IMissionSkillRepository missionSkillRepository) : IMissionService {
        private readonly IMissionRepository _missionRepository = missionRepository;
        private readonly IMissionSkillRepository _missionSkillRepository = missionSkillRepository;

        public Task<bool> AddMission(MissionRequestViewModel model) {
            var mission = new Entities.Missions() {
                CityId = model.CityId,
                CountryId = model.CountryId,
                EndDate = model.EndDate,
                MissionDescription = model.MissionDescription,
                MissionImages = model.MissionImages,
                MissionSkillId = model.MissionSkillId,
                MissionThemeId = model.MissionThemeId,
                MissionTitle = model.MissionTitle,
                StartDate = model.StartDate,
                TotalSheets = model.TotalSeats,
            };

            return _missionRepository.AddMission(mission);
        }

        public Task<List<MissionRequestViewModel>> GetAllMissionAsync() {
            return _missionRepository.GetAllMissionAsync();
        }

        public Task<MissionRequestViewModel?> GetMissionById(int id) {
            return _missionRepository.GetMissionById(id);
        }

        public async Task<IList<MissionDetailResponseModel>> GetAllClientMissions() {
            var missions = await _missionRepository.ClientSideMissionList(); // Gets all missions

            return missions.Select(m => new MissionDetailResponseModel() {
                Id = m.Id,
                EndDate = m.EndDate,
                StartDate = m.StartDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionTitle = m.MissionTitle,
                TotalSheets = m.TotalSheets,
                RegistrationDeadLine = m.RegistrationDeadLine,
                CityId = m.CityId,
                CityName = m.City.CityName,
                CountryId = m.CountryId,
                CountryName = m.Country.CountryName,
                MissionSkillId = m.MissionSkillId,
                MissionSkillName = _missionSkillRepository.GetMissionSkills(m.MissionSkillId),
                MissionThemeId = m.MissionThemeId,
                MissionThemeName = m.MissionTheme.ThemeName,

                // Since no user context, apply default labels:
                MissionApplyStatus = "Apply",
                MissionApproveStatus = "N/A",
                MissionStatus = m.RegistrationDeadLine < DateTime.Now.AddDays(-1) ? "Closed" : "Available"
            }).ToList();
        }


        // int userId
        public async Task<IList<MissionDetailResponseModel>> ClientSideMissionList(int userId) {
            var missions = await _missionRepository.ClientSideMissionList();

            return missions.Select(m => new MissionDetailResponseModel() {
                Id = m.Id,
                EndDate = m.EndDate,
                StartDate = m.StartDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionTitle = m.MissionTitle,
                TotalSheets = m.TotalSheets,
                RegistrationDeadLine = m.RegistrationDeadLine,
                CityId = m.CityId,
                CityName = m.City.CityName,
                CountryId = m.CountryId,
                CountryName = m.Country.CountryName,
                MissionSkillId = m.MissionSkillId,
                MissionSkillName = _missionSkillRepository.GetMissionSkills(m.MissionSkillId),
                MissionThemeId = m.MissionThemeId,
                MissionThemeName = m.MissionTheme.ThemeName,

                MissionApplyStatus = m.MissionApplications.Any(m => m.UserId == userId) ? "Applied" : "Apply",
                MissionApproveStatus = m.MissionApplications.Any(m => m.UserId == userId && m.Status == true) ? "Approved" : "Applied",
                MissionStatus = m.RegistrationDeadLine < DateTime.Now.AddDays(-1) ? "Closed" : "Available"
            }).ToList();

        }

        public async Task<bool> ApplyMission(AddMissionApplicationRequestModel model) {
            return await _missionRepository.ApplyMission(model);
        }

        public List<MissionApplication> GetMissionApplicationList() {
            return _missionRepository.GetMissionApplicationList();
        }

        public async Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication) {
            return await _missionRepository.MissionApplicationApprove(missionApplication);
        }
    }
}
