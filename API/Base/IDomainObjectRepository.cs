using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public interface IDomainObjectRepository<T>
    {
        /// <summary>
        /// Récupère un objet de type T à partir de son identifiant unique.
        /// </summary>
        /// <param name="id">L'identifiant unique.</param>
        /// <returns>L'objet de type T.</returns>
        T FindById(int id);

        /// <summary>
        /// Récupère une liste de tous les objets de type T.
        /// </summary>
        /// <returns>Une liste d'objet de type T.</returns>
        List<T> FindAll();

        /// <summary>
        /// Insertion d'un ojet de type T.
        /// </summary>
        /// <param name="domainObject">L'objet à insérer.</param>
        void Insert(T domainObject);

        /// <summary>
        /// Mise à jour d'un objet de type T.
        /// </summary>
        /// <param name="domainObject">L'objet à mettre à jour.</param>
        void Update(T domainObject);

        /// <summary>
        /// Suppression d'un objet de type T.
        /// </summary>
        /// <param name="domainObject">L'objet à supprimer.</param>
        void Delete(int id);
    }
}
