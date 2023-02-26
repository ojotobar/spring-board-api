﻿using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories;
using Services.Contracts;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ILocationService> _locationService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IUserInformationService> _userInformationService;
        private readonly Lazy<IEducationService> _educationService;
        private readonly Lazy<IWorkExperienceService> _workExperienceService;
        private readonly Lazy<ISkillService> _skillService;
        private readonly Lazy<IUserSkillService> _userSkillService;
        private readonly Lazy<ICertificationService> _certificationService;
        private readonly Lazy<IJobService> _jobService;
        private readonly Lazy<IJobTypeService> _jobTypeService;
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IIndustryService> _industryService;
        private readonly Lazy<ICareerSummaryService> _careerSummaryService;

        public ServiceManager(
            IRepositoryManager repositoryManager, 
            ILoggerManager logger,
            IMapper mapper,
            IConfiguration config,
            UserManager<AppUser> userManager,
            IEmailService emailService,
            SignInManager<AppUser> signInManager,
            ICloudinaryService cloudinaryService,
            RepositoryContext repositoryContext,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _locationService = new Lazy<ILocationService>(() => new
                LocationService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new 
                AuthenticationService(logger, mapper, userManager, config, emailService, repositoryManager, signInManager));
            _userService = new Lazy<IUserService>(() => new 
                UserService(logger, mapper, userManager, config, repositoryManager, cloudinaryService, repositoryContext, httpContextAccessor));
            _userInformationService = new Lazy<IUserInformationService>(() => new
                UserInformationService(logger, mapper, repositoryManager));
            _educationService = new Lazy<IEducationService>(() => new
                EducationService(repositoryManager, mapper));
            _workExperienceService = new Lazy<IWorkExperienceService>(() => new
                WorkExperienceService(repositoryManager, mapper));
            _skillService = new Lazy<ISkillService>(() => new
                SkillService(repositoryManager, mapper));
            _userSkillService = new Lazy<IUserSkillService>(() => new
                UserSkillService(repositoryManager, mapper));
            _certificationService = new Lazy<ICertificationService>(() => new
                CertificationService(repositoryManager, mapper));
            _jobService = new Lazy<IJobService>(() => new
                JobService(repositoryManager, mapper, emailService, userManager));
            _jobTypeService = new Lazy<IJobTypeService>(() => new
                JobTypeService(repositoryManager, mapper));
            _companyService = new Lazy<ICompanyService>(() => new
                CompanyService(repositoryManager, mapper, cloudinaryService));
            _industryService = new Lazy<IIndustryService>(() => new
                IndustryService(repositoryManager, mapper));
            _careerSummaryService = new Lazy<ICareerSummaryService>(() => new
                CareerSummaryService(repositoryManager, mapper, logger));
        }
        public ILocationService Location => _locationService.Value;
        public IAuthenticationService Authentication => _authenticationService.Value;
        public IUserService User => _userService.Value;
        public IUserInformationService UserInformation => _userInformationService.Value;
        public IEducationService Education => _educationService.Value;
        public IWorkExperienceService WorkExperience => _workExperienceService.Value;
        public ISkillService Skill => _skillService.Value;
        public IUserSkillService UserSkill => _userSkillService.Value;
        public ICertificationService Certification => _certificationService.Value;

        public IJobService Job => _jobService.Value;

        public IJobTypeService JobType => _jobTypeService.Value;

        public ICompanyService Company => _companyService.Value;

        public IIndustryService Industry => _industryService.Value;

        public ICareerSummaryService CareerSummary => _careerSummaryService.Value;
    }
}
