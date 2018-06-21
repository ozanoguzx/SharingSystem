using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IRepository<T>
    {
        bool Ekle(T c);

        bool Guncelle(T c);

        bool Sil(int id);

        List<T> HepsiniGetir();

        T TekGetir(int id);
    }

}
