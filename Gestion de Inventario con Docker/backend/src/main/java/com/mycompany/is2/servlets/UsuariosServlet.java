package com.mycompany.is2.servlets;

import java.io.IOException;
import java.sql.*;
import jakarta.servlet.*;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.*;

@WebServlet(name = "UsuariosServlet", urlPatterns = {"/UsuariosServlet"})
public class UsuariosServlet extends HttpServlet {
    
 private static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
private static final String DB_URL = "jdbc:mysql://database:3306/ITEMCONTROL?useSSL=false&serverTimezone=UTC&allowPublicKeyRetrieval=true&useUnicode=true&characterEncoding=UTF-8";
private static final String USER = "appuser";
private static final String PASS = "apppass";
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Manejar eliminación de usuarios
        String action = request.getParameter("action");
        String username = request.getParameter("user");
        
        if ("delete".equals(action) && username != null) {
            Connection conn = null;
            PreparedStatement pstmt = null;

            try {
                Class.forName(JDBC_DRIVER);
                conn = DriverManager.getConnection(DB_URL, USER, PASS);

                String sql = "DELETE FROM Usuarios WHERE nombre_De_Usuario = ?";
                pstmt = conn.prepareStatement(sql);
                pstmt.setString(1, username);
                int rowsAffected = pstmt.executeUpdate();

                if (rowsAffected > 0) {
                    response.sendRedirect("UsuariosGerente.jsp?status=success&message=Usuario eliminado correctamente");
                } else {
                    response.sendRedirect("UsuariosGerente.jsp?status=error&message=No se encontró el usuario a eliminar");
                }
            } catch (ClassNotFoundException | SQLException e) {
                response.sendRedirect("UsuariosGerente.jsp?status=error&message=Error al eliminar usuario: " + e.getMessage());
            } finally {
                try {
                    if (pstmt != null) pstmt.close();
                    if (conn != null) conn.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Manejar inserción y actualización de usuarios
        String action = request.getParameter("action");
        String username = request.getParameter("username");
        String password = request.getParameter("password");
        String role = request.getParameter("role");

        Connection conn = null;
        PreparedStatement pstmt = null;

        try {
            Class.forName(JDBC_DRIVER);
            conn = DriverManager.getConnection(DB_URL, USER, PASS);

            if ("insert".equals(action)) {
                // Insertar nuevo usuario
                String sql = "INSERT INTO Usuarios (nombre_De_Usuario, contrasena, rol, fecha_De_Alta) VALUES (?, ?, ?, NOW())";                    
                pstmt = conn.prepareStatement(sql);
                pstmt.setString(1, username);
                pstmt.setString(2, password);
                pstmt.setString(3, role);

                int rowsAffected = pstmt.executeUpdate();

                if (rowsAffected > 0) {
                    response.sendRedirect("UsuariosGerente.jsp?status=success&message=Usuario agregado correctamente");
                } else {
                    response.sendRedirect("UsuariosGerente.jsp?status=error&message=Error al agregar usuario");
                }

            } else if ("update".equals(action)) {
                // Actualizar usuario existente
                String oldUsername = request.getParameter("oldUsername");
                String sql = "UPDATE Usuarios SET nombre_De_Usuario = ?, contrasena = ?, rol = ? WHERE nombre_De_Usuario = ?";
                pstmt = conn.prepareStatement(sql);
                pstmt.setString(1, username);
                pstmt.setString(2, password);
                pstmt.setString(3, role);
                pstmt.setString(4, oldUsername);

                int rowsAffected = pstmt.executeUpdate();

                if (rowsAffected > 0) {
                    response.sendRedirect("UsuariosGerente.jsp?status=success&message=Usuario actualizado correctamente");
                } else {
                    response.sendRedirect("UsuariosGerente.jsp?status=error&message=Error al actualizar usuario");
                }
            }

        } catch (ClassNotFoundException e) {
            response.sendRedirect("UsuariosGerente.jsp?status=error&message=Error de clase: " + e.getMessage());

        } catch (SQLException e) {
            String errorMsg = e.getMessage();
            // Detectar error por clave duplicada
            if (errorMsg.toLowerCase().contains("duplicate entry")) {
            response.sendRedirect("UsuariosGerente.jsp?status=error&message=El nombre de usuario '" + username + "' ya esta registrado. Intenta con otro.");
            } else {
                response.sendRedirect("UsuariosGerente.jsp?status=error&message=Error en la operación: " + errorMsg);
            }

        } finally {
            try {
                if (pstmt != null) pstmt.close();
                if (conn != null) conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
}