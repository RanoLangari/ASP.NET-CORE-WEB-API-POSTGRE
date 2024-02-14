using CRUD_ASP.POSTGRESQL.Context;
using CRUD_ASP.POSTGRESQL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP.POSTGRESQL.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;

        public BarangController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetBarang()
        {
            var data = await _myDbContext.TblBarangs.ToListAsync();
            return Ok(new {Success = true, Data=data});
        }

        [HttpPost]
        public async Task<IActionResult> PostBarang(TblBarang barang)
        {
            _myDbContext.TblBarangs.AddAsync(barang);
            await _myDbContext.SaveChangesAsync();
            return Ok(new { Success = true, Message = "Berhasil Menambahkan Data Barang" });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarang(int id, DataBarang barang)
        {
            if (!BarangExists(id))
            {
                return NotFound();
            }
            TblBarang EditBarang = _myDbContext.TblBarangs.Find(id);
            EditBarang.NamaBarang = barang.NamaBarang;
            EditBarang.KategoriBarang = barang.KategoriBarang;
            await _myDbContext.SaveChangesAsync();
            return Ok(new { Success = true, Message = "Barang Berhasil Diubah" });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarang(int id)
        {
            var Data =  _myDbContext.TblBarangs.Find(id);
            if (Data == null)
            {
                return NotFound();
            }
             _myDbContext.TblBarangs.Remove(Data);
             await _myDbContext.SaveChangesAsync();
             return Ok(new { Message = "Barang Berhasil DIhapus" });
        }
        private bool BarangExists(int id)
        {
            return _myDbContext.TblBarangs.Any(e => e.IdBarang == id);
        }

    }
}
