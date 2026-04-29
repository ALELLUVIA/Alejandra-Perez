/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

/**
 *
 * @author Lluvia Alejandra
 */

import java.sql.*;

public class TestConnection {
    public static void main(String[] args) {
        System.out.println("🔍 PROBANDO CONEXIÓN A MYSQL...");
        
        try {
            // 1. Cargar driver
            Class.forName("com.mysql.cj.jdbc.Driver");
            System.out.println("✅ Driver MySQL cargado");
            
            // 2. Datos de conexión
            String url = "jdbc:mysql://localhost:3306/ITEMCONTROL?useSSL=false&serverTimezone=UTC&allowPublicKeyRetrieval=true";            
            String user = "root";
            String password = "LLUVIAalejandra2003";
            
            System.out.println("🔗 Intentando conectar: " + url);
            System.out.println("👤 Usuario: " + user);
            
            // 3. Conectar
            Connection conn = DriverManager.getConnection(url, user, password);
            System.out.println("✅ CONEXIÓN EXITOSA A MYSQL");
            
            // 4. Probar consulta
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery("SELECT * FROM Usuarios");
            
            System.out.println("📊 USUARIOS EN LA BD:");
            while (rs.next()) {
                System.out.println(" - " + rs.getString("nombre_De_Usuario") + 
                                 " | " + rs.getString("rol"));
            }
            
            // 5. Cerrar conexión
            conn.close();
            System.out.println("✅ PRUEBA COMPLETADA");
            
        } catch (ClassNotFoundException e) {
            System.out.println("❌ ERROR: Driver MySQL no encontrado");
            System.out.println("   Verifica la dependencia en pom.xml");
            e.printStackTrace();
        } catch (SQLException e) {
            System.out.println("❌ ERROR SQL: " + e.getMessage());
            System.out.println("   Código error: " + e.getErrorCode());
            e.printStackTrace();
        } catch (Exception e) {
            System.out.println("❌ ERROR: " + e.getMessage());
            e.printStackTrace();
        }
    }
}