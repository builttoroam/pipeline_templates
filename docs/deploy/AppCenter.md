---
title: App Center Deployment Template
description: Template for distributing Android, iOS and Windows apps to testers via App Center
author: Nick Randolph
---

# App Center Deployment Template

Use this template to simplify the distribution of Android, iOS and Windows (UWP) applications to testers and users through App Center.

## YAML snippet

```yaml
# App Center Deployment Template
# Template for distributing Android, iOS and Windows apps to testers via App Center
stages:
- template:  azure/mobile/deploy-appcenter.yml@builttoroam_templates
  parameters:
    artifact_folder: 
    application_package: 
    appcenter_service_connection: 
    appcenter_organisation:
    appcenter_applicationid:
    #stage_name: 'Deploy_App_Center' # Optional
    #depends_on: # Optional 
    #deploy_appcenter_enabled: true # Optional 
    #environment_name: 'Default Environment' # Optional
    #artifact_name: 'drop' # Optional 
    #appcenter_release_notes: # Optional 
    #appcenter_release_notes_option: 'input' # Options: input, file
    #appcenter_release_notes_file: # Required when appcenter_release_notes_option == Input 
    #appcenter_is_mandatory_update: # Required when appcenter_release_notes_option == File
    #appcenter_destination_type: 'groups' # Options: groups, store
    #appcenter_distribution_group_ids: # Optional
    #appcenter_destination_store_id: # Required when appcenter_destination_type == store. The id of the destination store
    #appcenter_dont_notify_testers: false # Optional
    #secure_file_keystore_filename: # Required if the application package is AAB
    #keystore_alias: # Required if the application package is AAB
    #keystore_password: # Required if the application package is AAB
    #onStart: # Optional
    #postArtifactDownload: # Optional
    #preAppCenterPublish: # Optional
    #onEnd: # Optional


```


## Arguments

<table><thead><tr><th>Argument</th><th>Description</th></tr></thead>
<tr><td>artifact_folder</td><td>(Required) The name of the folder to copy application from in the artifact</td></tr>
<tr><td>application_package</td><td>(Required) The name of the application package to deploy</td></tr> 
<tr><td>appcenter_service_connection</td><td>(Required) The name of the service connection that connects Azure DevOps to App Center. Go to Service Connections in Azure DevOps to setup the connection and assign permissions for pipelines to access it</td></tr> 
<tr><td>appcenter_organisation</td><td>(Required) The organisation (or individual) in App Center that the application  is associated with. In AppCenter navigate to the application and extract organisation from URL eg https://appcenter.ms/users/[organisation]/apps/[applicationid] More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devop</td></tr>
<tr><td>appcenter_applicationid</td><td>(Required) The application id in App Center that identifies  the application. In AppCenter navigate to the application and extract application id from URL eg https://appcenter.ms/users/[organisation]/apps/[applicationid] More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr>
<tr><td>stage_name</td><td>(Optional) The name of the stage, so that it can be referenced elsewhere (eg for dependsOn property)</td></tr> 
<tr><td>depends_on</td><td>(Optional) The array of stages that this stage depends on. Default is that this stage does not depend on any other stage. However, since this is a deployment stage, you'll probably want to specify a build stage that this stage depends on</td></tr> 
<tr><td>deploy_appcenter_enabled</td><td>(Optional) Whether this stages should be executed. Note that setting this to false won't completely cancel the stage, it will merely skip most of the stages. The stage will appear to complete successfully, so any stages that depend on this stage will attempt to execute</td></tr> 
<tr><td>environment_name</td><td>(Optional) The environment to deploy to. Can be used to introduce a manual gate for approval for stage to proceed</td></tr> 
<tr><td>artifact_name</td><td>(Optional) The name of the artifact to copy application from</td></tr>  
<tr><td>appcenter_release_notes_option</td><td>(Optional) Whether release notes for App Center should be inputted via the appcenter_release_notes parameter or if it should come from a file (appcenter_release_notes_file parameter).  More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr> 
<tr><td>appcenter_release_notes</td><td>(Optional) The release notes to be set in App Center for the release. More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr> 
<tr><td>appcenter_release_notes_file</td><td>(Optional) The file to read the release notes from to be set in App Center for the release. More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr> 
<tr><td>appcenter_is_mandatory_update</td><td>(Optional) Whether the App Center release should be marked as a mandatory update. More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr>
<tr><td>appcenter_destination_type</td><td>(Optional) Whether the release is pushed out to a distribution group or a store. More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr> 
<tr><td>appcenter_distribution_group_ids</td><td>(Optional) The id(s) (comma separated list of guids) of the distribution groups to distribute the release to. More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr>
<tr><td>appcenter_destination_store_id</td><td>(Optional) The id of the destination store. More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr>
<tr><td>appcenter_dont_notify_testers</td><td>(Optional) Whether testers are notified about an App Center release. More information at https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/app-center-distribute?view=azure-devops</td></tr> 
<tr><td>secure_file_keystore_filename</td><td>(Optiona) IMPORTANT: This is required if application package is an AAB. The keystore file used to sign the APK when extracte from an AAB. This is the name of the keystore in Secure Files.</td></tr> 
<tr><td>keystore_alias</td><td>(Optional) IMPORTANT: This is required if application package is an AAB. The alias of the keystore.</td></tr> 
<tr><td>keystore_password</td><td>(Optional) IMPORTANT: This is required if application package is an AAB. The password to access the keystore</td></tr> 
<tr><td>onStart</td><td>(Optional) Steps to be executed before stage starts</td></tr> 
<tr><td>postArtifactDownload</td><td>(Optional) Steps to be executed after artifacts from previous stages have been downloaded</td></tr> 
<tr><td>preAppCenterPublish</td><td>(Optional) Steps to be executed before application package is published to App Center</td></tr> 
<tr><td>onEnd</td><td>(Optional) Steps to be executed at the end of the stage</td></tr>

</table>

<!-- ## Example

This example pipeline builds an Android app, runs tests, and publishes the app using App Center Distribute.

```yaml
# Android
# Build your Android project with Gradle.
# Add steps that test, sign, and distribute the APK, save build artifacts, and more:
# https://docs.microsoft.com/azure/devops/pipelines/ecosystems/android

pool:
  vmImage: 'macOS-latest'
steps:

  - script: sudo npm install -g appcenter-cli
  - script: appcenter login --token {YOUR_TOKEN}

  - task: Gradle@2
    inputs:
      workingDirectory: ''
      gradleWrapperFile: 'gradlew'
      gradleOptions: '-Xmx3072m'
      publishJUnitResults: false
      testResultsFiles: '**/TEST-*.xml'
      tasks: build

  - task: CopyFiles@2
    inputs:
      contents: '**/*.apk'
      targetFolder: '$(build.artifactStagingDirectory)'

  - task: PublishBuildArtifacts@1
    inputs:
      pathToPublish: '$(build.artifactStagingDirectory)'
      artifactName: 'outputs'
      artifactType: 'container'

  # Run tests using the App Center CLI
  - script: appcenter test run espresso --app "{APP_CENTER_SLUG}" --devices "{DEVICE}" --app-path {APP_FILE} --test-series "master" --locale "en_US" --build-dir {PAT_ESPRESSO} --debug

  # Distribute the app
  - task: AppCenterDistribute@3
    inputs:
      serverEndpoint: 'AppCenter'
      appSlug: '$(APP_CENTER_SLUG)'
      appFile: '$(APP_FILE)' # Relative path from the repo root to the APK or IPA file you want to publish
      symbolsOption: 'Android'
      releaseNotesOption: 'input'
      releaseNotesInput: 'Here are the release notes for this version.'
      destinationType: 'groups'
``` -->

## Open source

This template is open source [on GitHub](https://github.com/builttoroam/pipeline_templates). Feedback and contributions are welcome.
