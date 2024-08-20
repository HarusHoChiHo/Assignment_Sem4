FROM maven:3.8.4-openjdk-17 AS build
WORKDIR /app

COPY ./JavaSB/mvnw .
COPY ./JavaSB/.mvn .mvn
COPY ./JavaSB/pom.xml .
COPY ./JavaSB/src ./src
RUN ./mvnw clean package -DskipTests

FROM openjdk:17-jdk-slim
COPY --from=build /app/target/*.jar app.jar
ENTRYPOINT ["java", "-jar", "/app.jar"]