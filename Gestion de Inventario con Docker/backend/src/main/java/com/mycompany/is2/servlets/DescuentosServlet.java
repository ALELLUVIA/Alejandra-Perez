package com.mycompany.is2.servlets;

import java.io.IOException;
import java.sql.*;
import jakarta.servlet.*;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.*;
import java.util.ArrayList;
import java.util.List;

@WebServlet(name = "DescuentosServlet", urlPatterns = {"/DescuentosServlet"})
public class DescuentosServlet extends HttpServlet {
    
private static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
private static final String DB_URL = "jdbc:mysql://database:3306/ITEMCONTROL?useSSL=false&serverTimezone=UTC&allowPublicKeyRetrieval=true&useUnicode=true&characterEncoding=UTF-8";
private static final String USER = "appuser";
private static final String PASS = "apppass";
    @Override
protected void doGet(HttpServletRequest request, HttpServletResponse response)
        throws ServletException, IOException {
    // Manejar eliminación de promociones
    String action = request.getParameter("action");
    String idParam = request.getParameter("id");
    
    // Aquí añadimos la lista de productos
    List<String> productos = new ArrayList<>();
    
    Connection conn = null;
    PreparedStatement pstmt = null;
    ResultSet rs = null;
    
    try {
        Class.forName(JDBC_DRIVER);
        conn = DriverManager.getConnection(DB_URL, USER, PASS);

        // Obtener lista de nombres de productos
        String sqlProductos = "SELECT nombre_Producto FROM Productos";
        pstmt = conn.prepareStatement(sqlProductos);
        rs = pstmt.executeQuery();
        while (rs.next()) {
            productos.add(rs.getString("nombre_Producto"));
        }
        rs.close();
        pstmt.close();
        
        // Si viene acción delete, hacemos la eliminación como antes
        if ("delete".equals(action) && idParam != null) {
            int id = Integer.parseInt(idParam);

            String sqlDelete = "DELETE FROM Promociones WHERE id_Promocion = ?";
            pstmt = conn.prepareStatement(sqlDelete);
            pstmt.setInt(1, id);
            int rowsAffected = pstmt.executeUpdate();
            
            if (rowsAffected > 0) {
                response.sendRedirect("DescuentosGerente.jsp?status=success&message=PROMOCION eliminada correctamente");
                return; // para salir antes de forward
            } else {
                response.sendRedirect("DescuentosGerente.jsp?status=error&message=No se encontro la promocion a eliminar");
                return;
            }
        }
        
    } catch (Exception e) {
        e.printStackTrace();
    } finally {
        try {
            if (rs != null) rs.close();
            if (pstmt != null) pstmt.close();
            if (conn != null) conn.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    
    // Pasar la lista de productos a la JSP
    request.setAttribute("listaProductos", productos);

    // Además recibir el producto seleccionado, si existe, desde parámetro
    String productoSeleccionado = request.getParameter("productoSeleccionado");
    request.setAttribute("productoSeleccionado", productoSeleccionado);

    // Finalmente, forward para mostrar la JSP
    request.getRequestDispatcher("DescuentosGerente.jsp").forward(request, response);
}

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Manejar inserción y actualización de promociones
        String action = request.getParameter("action");
        String idParam = request.getParameter("idPromocion");
        String porcentajeParam = request.getParameter("porcentaje");
        String fechaInicio = request.getParameter("fechaInicio");
        String fechaFin = request.getParameter("fechaFin");
        String estado = request.getParameter("estado");
        
        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs = null;
        
        try {
            Class.forName(JDBC_DRIVER);
            conn = DriverManager.getConnection(DB_URL, USER, PASS);
            
            if("insert".equals(action)) {
                // Obtener el próximo ID disponible
                int nextId = 1;
                Statement stmt = conn.createStatement();
                rs = stmt.executeQuery("SELECT MAX(id_Promocion) AS max_id FROM Promociones");
                if(rs.next()) {
                    nextId = rs.getInt("max_id") + 1;
                }
                
                // Insertar nueva promoción con el ID generado
                String sql = "INSERT INTO Promociones (id_Promocion, porcentaje_De_Descuento,  fecha_De_inicio, fecha_De_Fin, estado) VALUES (?, ?, ?, ?, ?)";
                pstmt = conn.prepareStatement(sql);
                pstmt.setInt(1, nextId);
                pstmt.setInt(2, Integer.parseInt(porcentajeParam));
                pstmt.setDate(3, Date.valueOf(fechaInicio));
                pstmt.setDate(4, Date.valueOf(fechaFin));
                pstmt.setString(5, estado);
                
                int rowsAffected = pstmt.executeUpdate();
                
                if(rowsAffected > 0) {
                    response.sendRedirect("DescuentosGerente.jsp?status=success&message=Promocion agregada correctamente con ID: " + nextId);
                } else {
                    response.sendRedirect("DescuentosGerente.jsp?status=error&message=Error al agregar promocion");
                }
                
                if(stmt != null) stmt.close();
            } else if("update".equals(action) && idParam != null) {
                // Actualizar promoción existente
                String sql = "UPDATE Promociones SET porcentaje_De_Descuento = ?, fecha_De_inicio = ?, fecha_De_Fin = ?, estado = ? WHERE id_Promocion = ?";
                pstmt = conn.prepareStatement(sql);
                pstmt.setInt(1, Integer.parseInt(porcentajeParam));
                pstmt.setDate(2, Date.valueOf(fechaInicio));
                pstmt.setDate(3, Date.valueOf(fechaFin));
                pstmt.setString(4, estado);
                pstmt.setInt(5, Integer.parseInt(idParam));
                
                int rowsAffected = pstmt.executeUpdate();
                
                if(rowsAffected > 0) {
                    response.sendRedirect("DescuentosGerente.jsp?status=success&message=Promocion actualizada correctamente");
                } else {
                    response.sendRedirect("DescuentosGerente.jsp?status=error&message=Error al actualizar promocion");
                }
            }
        } catch (NumberFormatException e) {
            response.sendRedirect("DescuentosGerente.jsp?status=error&message=Formato de numero invalido");
        } catch (IllegalArgumentException e) {
            response.sendRedirect("DescuentosGerente.jsp?status=error&message=Formato de fecha invalido");
        } catch (ClassNotFoundException | SQLException e) {
            response.sendRedirect("DescuentosGerente.jsp?status=error&message=Error en la operacion: " + e.getMessage());
        } finally {
            try {
                if(rs != null) rs.close();
                if(pstmt != null) pstmt.close();
                if(conn != null) conn.close();
            } catch(SQLException e) {
                e.printStackTrace();
            }
        }
    }
}