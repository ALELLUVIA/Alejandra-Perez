# FASE 1: Compilar con Maven
FROM maven:3.8-openjdk-11 AS builder

WORKDIR /app
COPY pom.xml .
COPY src ./src
RUN mvn clean package -DskipTests

# FASE 2: Ejecutar con Tomcat  
FROM tomcat:10.1-jdk11  

# Copiar el .war a Tomcat
COPY --from=builder /app/target/IS2-1.0-SNAPSHOT.war /usr/local/tomcat/webapps/ROOT.war

EXPOSE 8080

CMD ["catalina.sh", "run"]