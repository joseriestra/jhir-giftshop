using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Utils;

namespace Business.General
{
    /// <summary>
    /// Business Base Class for Repository Creation.
    /// </summary>
    public class BaseBusiness
    {
        private FactoryRepository factory;

        protected FactoryRepository Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = new FactoryRepository();
                }
                return factory;
            }
        }
    }
}
