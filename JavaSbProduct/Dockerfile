FROM amazoncorretto:17-alpine-jdk

RUN apk add --no-cache curl
RUN apk add --no-cache dos2unix

WORKDIR /app

COPY pom.xml .

COPY src ./src

COPY .mvn .mvn
COPY mvnw .

RUN chmod +x mvnw

#Convert the line ending to Linux EOL
RUN dos2unix mvnw

RUN ./mvnw package -DskipTests

EXPOSE 8091

ENTRYPOINT ["java", "-jar", "target/JavaSbProduct-0.0.1-SNAPSHOT.jar"]