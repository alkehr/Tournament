using System.Collections.Generic;
using System.Linq;
using Tournament.WpfApp.Core;

namespace Tournament.WpfApp.ViewModels
{
    public class PoolViewModel
    {
        private readonly Pool _pool;

        public PoolViewModel(Pool pool)
        {
            _pool = pool;
        }

        public string PoolName
        {
            get { return _pool.Name; }
        }

        public string Location
        {
            get { return _pool.Location; }
        }

        public IEnumerable<TeamViewModel> Teams
        {
            get { return _pool.Teams.Select(t => new TeamViewModel(t, _pool)); }
        }
    }
}
