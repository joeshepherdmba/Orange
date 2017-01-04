using Orange.Data;
using Orange.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context = null;
        private UserRepository _userRepository;
        private Repository<MarketingItem> _itemRepository;
        private Repository<Share> _shareRepository;
        private Repository<Token> _tokenRepository;

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public UserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for MarketingItem repository.
        /// </summary>
        public Repository<MarketingItem> ItemRepository
        {
            get
            {
                if (this._itemRepository == null)
                    this._itemRepository = new Repository<MarketingItem>(_context);
                return _itemRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Share repository.
        /// </summary>
        public Repository<Share> ShareRepository
        {
            get
            {
                if (this._shareRepository == null)
                    this._shareRepository = new Repository<Share>(_context);
                return _shareRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public Repository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new Repository<Token>(_context);
                return _tokenRepository;
            }
        }

        #endregion
        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
