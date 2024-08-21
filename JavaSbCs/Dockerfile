# Use OpenJDK 17 as the base image
FROM amazoncorretto:17-alpine-jdk

RUN apk add --no-cache curl

# Set the working directory in the container
WORKDIR /app

# Copy the Maven project file
COPY pom.xml .

# Copy the source code
COPY src ./src

# Copy the Maven wrapper
COPY .mvn .mvn
COPY mvnw .

COPY config ./config

# Make the Maven wrapper executable
RUN chmod +x mvnw

# Build the application
RUN ./mvnw package -DskipTests

# Expose the port the app runs on
EXPOSE 8989

# Run the jar file
ENTRYPOINT ["java", "-jar", "target/JavaSbCs-0.0.1-SNAPSHOT.jar"]