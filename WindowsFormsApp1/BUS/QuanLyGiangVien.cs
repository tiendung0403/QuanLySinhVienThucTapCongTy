﻿using System;
using System.Collections.Generic;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BUS
{
    [Serializable]

    internal class QuanLyGiangVien
    {
        private List<GiangVien> DanhsachGiangVien;

        public QuanLyGiangVien()
        {
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoitao();
            this.DanhsachGiangVien = duLieu.getDanhSachGiangVien();
        }

        public List<GiangVien> getDanhSachGV()
        {
            return this.DanhsachGiangVien;
        }

        public GiangVien Tim(string ma)
        {
            return this.DanhsachGiangVien.Find(gv => gv.MaGiangVien == ma);
        }

        public bool Them(GiangVien a)
        {
            if (Tim(a.MaGiangVien) == null)
            {
                this.DanhsachGiangVien.Add(a);
                return true;
            }
            return false;
        }

        public bool Xoa(string ma)
        {
            var cty = Tim(ma);
            if (cty != null)
            {
                this.DanhsachGiangVien.Remove(cty);
                return true;
            }
            return false;
        }

        public bool Sua(GiangVien a)
        {
            GiangVien ketQuaTim = Tim(a.MaGiangVien);
            if (ketQuaTim != null)
            {
                ketQuaTim.MaGiangVien = a.MaGiangVien;
                ketQuaTim.HoTen = a.HoTen;
                ketQuaTim.GioiTinh = a.GioiTinh;
                ketQuaTim.NgaySinh = a.NgaySinh;
                ketQuaTim.ChucVu = a.ChucVu;
                ketQuaTim.Email = a.Email;
                ketQuaTim.SoDienThoai = a.SoDienThoai;
                return true;
            }
            return false;
        }

    }
}
