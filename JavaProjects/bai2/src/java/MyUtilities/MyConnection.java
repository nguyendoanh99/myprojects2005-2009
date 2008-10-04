/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package MyUtilities;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author Nguyen Dang Khoa
 */
public class MyConnection {

    public static Connection getODBCConnection(String DB) throws ClassNotFoundException, SQLException {
        // Load the driver
        String className = "sun.jdbc.odbc.JdbcOdbcDriver";
        Class.forName(className);

        // Establish connection
        String url = "jdbc:odbc:" + DB;
        Connection con = DriverManager.getConnection(url);
        return con;
    }
}
