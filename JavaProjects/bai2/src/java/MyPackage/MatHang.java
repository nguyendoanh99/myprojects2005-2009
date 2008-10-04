/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package MyPackage;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 *
 * @author Nguyen Dang Khoa
 */
public class MatHang {

    int maMH;
    String tenMH;
    int donGia;
    String donViTinh;

    public MatHang(int maMH, String tenMH, int donGia, String donViTinh) {
        this.maMH = maMH;
        this.tenMH = tenMH;
        this.donGia = donGia;
        this.donViTinh = donViTinh;
    }

    public static MatHang CreateMatHang(ResultSet rs) throws SQLException {
        int maMH = rs.getInt("MaMH");
        String tenMH = rs.getString("TenMH");
        int donGia = rs.getInt("DonGia");
        String donViTinh = rs.getString("DonViTinh");

        MatHang mh = new MatHang(maMH, tenMH, donGia, donViTinh);
        return mh;
    }

    public String ToString() {
        String result = "";

        result = "<input type=\"checkbox\" name=\"" + String.valueOf(maMH) + "\"/>" +
                tenMH + "; Don Gia:" + String.valueOf(donGia) + "/" + donViTinh;
        return result;
    }

    public int getDonGia() {
        return donGia;
    }

    public void setDonGia(int donGia) {
        this.donGia = donGia;
    }

    public String getDonViTinh() {
        return donViTinh;
    }

    public void setDonViTinh(String donViTinh) {
        this.donViTinh = donViTinh;
    }

    public int getMaMH() {
        return maMH;
    }

    public void setMaMH(int maMatHang) {
        this.maMH = maMatHang;
    }

    public String getTenMH() {
        return tenMH;
    }

    public void setTenMH(String tenMH) {
        this.tenMH = tenMH;
    }
}
