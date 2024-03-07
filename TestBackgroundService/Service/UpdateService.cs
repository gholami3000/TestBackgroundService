using TestBackgroundService.Models;

namespace TestBackgroundService.Service
{
    public class UpdateService
    {
        private readonly MyAppContext _context;
        public UpdateService(MyAppContext context)
        {
            _context = context;
        }

        public void UpdateStatus1(Guid id)
        {
            //await Task.Run(() =>
            // {
            var item = _context.Request.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsActive = true;
                _context.SaveChanges();
            }

            //});

        }

        public  void UpdateStatus()
        {
           //await Task.Run(() =>
           // {
                var item = _context.Request.FirstOrDefault(x => x.IsActive == false);
                if (item != null)
                {
                    item.IsActive = true;
                    _context.SaveChanges();
                }

            //});

        }

    }
}

