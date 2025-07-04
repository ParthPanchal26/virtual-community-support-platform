﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCS.Entities.Entities;
using VCS.Entities.Models;
using VCS.Repositories.IRepositories;
using VCS.Services.IServices;

namespace VCS.Services.Services {
    public class MissionThemeService(IMissionThemeRepository missionThemeRepository) : IMissionThemeService {
        private readonly IMissionThemeRepository _missionThemeRepository = missionThemeRepository;
        public Task<bool> AddMissionTheme(MissionThemeViewModel model) {
            MissionTheme missionTheme = new MissionTheme() {
                Id = model.Id,
                Status = model.Status,
                ThemeName = model.ThemeName,
            };
            return _missionThemeRepository.AddMissionTheme(missionTheme);
        }

        public Task<bool> DeleteMissionTheme(int missionThemeId) {
            return _missionThemeRepository.DeleteMissionTheme(missionThemeId);
        }

        public Task<List<MissionThemeViewModel>> GetAllMissionTheme() {
            return _missionThemeRepository.GetAllMissionTheme();
        }

        public Task<MissionThemeViewModel?> GetMissionThemeById(int missionThemeId) {
            return _missionThemeRepository.GetMissionThemeById(missionThemeId);
        }

        public Task<bool> UpdateMissionTheme(MissionThemeViewModel model) {
            MissionTheme missionTheme = new MissionTheme() {
                Id = model.Id,
                Status = model.Status,
                ThemeName = model.ThemeName,
            };
            return _missionThemeRepository.UpdateMissionTheme(missionTheme);
        }
    }
}
