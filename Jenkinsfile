pipeline {
    agent any

    tools{
        dotnetsdk 'dotnet'
    }

    stages {
        stage('Tests') {
            steps {
                bat returnStatus: true, script: "dotnet test \"${workspace}/SeleniumPractice.sln\" --filter TestCategory=\"Bank Project\" --logger \"nunit;LogFileName=results.xml\""
                nunit failIfNoResults: true, testResultsPattern: '**/results.xml'
            }
        }
    }
}


