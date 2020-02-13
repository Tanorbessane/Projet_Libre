
namespace API
{
    public class Repository<TDomainObject>
    {
        APIContext  _container;

        public APIContext Container { get => _container; set => _container = value; }
        
        #region [ Constructeur ]
        public Repository(APIContext container)
        {
            _container = container;
        }     
        #endregion
    }
}
