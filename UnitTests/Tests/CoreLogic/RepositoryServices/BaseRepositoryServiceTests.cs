using System;
using System.Linq;
using CoreLogic.RepositoryServices;
using Entity;
using Entity.Models;
using NUnit.Framework;
using UnitTests.Helpers;

namespace UnitTests.Tests.CoreLogic.RepositoryServices
{
    public class BaseRepositoryServiceTests
    {
        private BaseRepositoryService<Account> _service;
        private ProjectContext _projectContext;

        [SetUp]
        public void SetUp()
        {
            _projectContext?.Database.EnsureDeleted();

            _projectContext = ContextHelper.GetContext();
            _service = new BaseRepositoryService<Account>(_projectContext);
        }
        
        [Test]
        public void All_EmptyTable()
        {
            Assert.AreEqual(0, _service.All.Count());
        }
        
        [Test]
        public void All_OneRow()
        {
            _projectContext.Add(new Account());
            _projectContext.SaveChanges();
            
            Assert.AreEqual(1, _service.All.Count());
        }
        
        [Test]
        public void Add_OneRow()
        {
            var newAccount = new Account() { Id = new Guid() };
            
            var createdEntity = _service.Add(newAccount);
            _service.SaveChanges();

            Assert.AreEqual(1, _projectContext.Accounts.Count());
            Assert.AreEqual(newAccount.Id, _projectContext.Accounts.First().Id);
            Assert.AreEqual(newAccount.Id, createdEntity.Id);
        }
        
        [Test]
        public void Delete_OneRow()
        {
            var newAccount = new Account() { Id = new Guid() };
            
            _projectContext.Accounts.Add(newAccount);
            _projectContext.SaveChanges();
            
            Assert.AreEqual(1, _projectContext.Accounts.Count());

            _service.Delete(newAccount);
            _service.SaveChanges();

            Assert.AreEqual(0, _projectContext.Accounts.Count());
        }
        
        [Test]
        public void Delete_OneRow_ById()
        {
            var newAccount = new Account() { Id = new Guid() };
            
            _projectContext.Accounts.Add(newAccount);
            _projectContext.SaveChanges();
            
            Assert.AreEqual(1, _projectContext.Accounts.Count());

            _service.Delete(newAccount.Id);
            _service.SaveChanges();

            Assert.AreEqual(0, _projectContext.Accounts.Count());
        }
        
        [Test]
        public void Update()
        {
            var newAccount = new Account() { Id = new Guid() };
            
            _projectContext.Accounts.Add(newAccount);
            _projectContext.SaveChanges();
            
            Assert.AreEqual(1, _projectContext.Accounts.Count());
            Assert.AreEqual(newAccount, _projectContext.Accounts.FirstOrDefault());
            
            _projectContext.ChangeTracker.Clear();

            var copiedEntity = new Account()
            {
                Id = newAccount.Id,
                Login = newAccount.Login,
                ModifyingDate = newAccount.ModifyingDate
            };

            var newLogin = "TEST1";
            copiedEntity.Login = newLogin;

            var result = _service.Update(copiedEntity);
            _service.SaveChanges();

            Assert.AreEqual(1, _projectContext.Accounts.Count());
            Assert.AreEqual(newLogin, result.Login);
        }
    }
}