package com.cleverbuilder

class GlobalVars {
   static String foo = "bar"
   def call() {
        stage('Checkout code') 
        {
            echo 'TEST'     
        }
   }
}
 
        //  checkout(
        //         [
        //             $class: 'GitSCM'
        //             ,branches: [
        //                 [name: '*/develop']
        //                 ]
        //             ,doGenerateSubmoduleConfigurations: false
        //             ,extensions: []
        //             ,submoduleCfg: []
        //             ,userRemoteConfigs: [
        //                 [
        //                 credentialsId: 'ade2829b-2ce1-437f-a17e-53f9cdd1333d'
        //                 ,url: 'https://gitlab.com/ss-trainee-2019/softsquaregroup-resource-management.git'
        //                 ]
        //             ]
        //         ]
        //     )
        // }