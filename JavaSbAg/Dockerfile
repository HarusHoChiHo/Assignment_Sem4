FROM amazoncorretto:17-alpine-jdk

RUN apk add --no-cache curl
RUN apk add --no-cache dos2unix

WORKDIR /app

COPY pom.xml .
COPY src ./src
COPY .mvn .mvn
COPY mvnw ./mvnw

RUN chmod +x mvnw

RUN dos2unix mvnw

RUN ./mvnw package -DskipTest

EXPOSE 8070

ENTRYPOINT ["java", "-jar","target/JavaSbAg-0.0.1-SNAPSHOT.jar"]

