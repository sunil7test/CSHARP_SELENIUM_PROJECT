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
                // Define the category you want to run
                 //   set /p testCategory = smoke 
                    // Define the test project path
                  //  set /p testProject = CSHARP_SELENIUM_PROJECT
                echo 'Testing..'
                //bat 'dotnet test %testProject%! --filter \"TestCategory=%testCategory%!\"'
                //bat 'dotnet test --filter TestCategory=smoke --logger html'
                bat 'dotnet test --filter TestCategory=smoke --logger:"nunit;LogFileName=TestResult.xml"'
                echo 'Test Completed'
            }
        }
        stage('Publish Results') {
                steps {
                    nunit testResultsPattern: 'TestResults/TestResult.xml'
                    }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}
