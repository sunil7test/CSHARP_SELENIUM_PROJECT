pipeline {
    agent any

    environment{
        DOTNET_CLI_TELEMETRY_OPTOUT='1'
        BROWSER= 'chrome'
    }

    stages {
        stage('Checkout Code'){
            steps{
                git url: 'https://github.com/sunil7test/CSHARP_SELENIUM_PROJECT.git', branch: 'master'
            }
        } 
        stage('Build') {
            steps {
                echo 'Building..'
                bat 'dotnet build'
                echo 'Build Completed'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                bat 'dotnet test CSHARP_SELENIUM_PROJECT.csproj'
                echo 'Build Completed'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}
