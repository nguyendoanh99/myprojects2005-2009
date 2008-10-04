/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package MyPackage;

import java.sql.ResultSet;
import java.sql.SQLException;

/**
 *
 * @author Nguyen Dang Khoa
 */
public class LinhKien {

    String maSo;
    String ten;
    int giaTien;

    public int getGiaTien() {
        return giaTien;
    }

    public void setGiaTien(int giaTien) {
        this.giaTien = giaTien;
    }

    public String getMaSo() {
        return maSo;
    }

    public void setMaSo(String maSo) {
        this.maSo = maSo;
    }

    public String getTen() {
        return ten;
    }

    public void setTen(String ten) {
        this.ten = ten;
    }

    public LinhKien(String maSo, String ten, int giaTien) {
        this.maSo = maSo;
        this.ten = ten;
        this.giaTien = giaTien;
    }
    
    public static LinhKien CreateLinkKien(ResultSet rs) throws SQLException
    {
        String maSo = rs.getString("MaSo");
        String ten = rs.getString("Ten");
        int giaTien = rs.getInt("GiaTien");
        return new LinhKien(maSo, ten, giaTien);
    }

    public String toString() {
        String result = "<option value=\"" + maSo + "\"> " + ten + " - " + giaTien +" USD" + "</option>";

        return result;
    }
    
}
