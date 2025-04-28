using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul9_2311104053.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        public class Mahasiswa
        {
            public string Nama { get; set; }
            public string Nim { get; set; }
        }

        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Marvel Sanjaya Setiawan", Nim = "2311104053" },
            new Mahasiswa { Nama = "Haza Zaidan Zidna Fann", Nim = "2311104056" },
            new Mahasiswa { Nama = "Candra Dinata", Nim = "2311104061" }
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return daftarMahasiswa;
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound();
            }
            return daftarMahasiswa[index];
        }

        [HttpPost]
        public void Post([FromBody] Mahasiswa mahasiswaBaru)
        {
            daftarMahasiswa.Add(mahasiswaBaru);
        }

        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            if (index >= 0 && index < daftarMahasiswa.Count)
            {
                daftarMahasiswa.RemoveAt(index);
            }
        }
    }
}
