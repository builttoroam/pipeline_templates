---
title: App Center Deployment Template
description: Template for distributing Android, iOS and Windows apps to testers via App Center
author: Nick Randolph
---

# App Center Deployment Template

Use this template to simplify the distribution of Android, iOS and Windows (UWP) applications to testers and users through App Center.

## YAML snippet

```YAML
# App Center Deployment Template
# Template for distributing Android, iOS and Windows apps to testers via App Center
stages:
- template:  azure/mobile/deploy-appcenter.yml@builttoroam_templates
  parameters:
    # Stage name and dependencies
    stage_name: 'Deploy_Android'
    depends_on: 'Build_Android'
    deploy_appcenter_enabled: $(android_enabled)
    environment_name: $(appcenter_environment)
    # Build artifacts
    artifact_folder: $(artifact_android_folder)
    application_package: $(android_application_package)
    # Signing information (for Android repack to APK)
    secure_file_keystore_filename: '$(android_keystore_filename)'
    keystore_alias: '$(android_keystore_alias)'
    keystore_password: '$(android_keystore_password)'
    # Deployment to AppCenter
    appcenter_service_connection: $(appcenter_service_connection)
    appcenter_organisation: $(appcenter_organisation)
    appcenter_applicationid: $(appcenter_android_appid)

# stage_name - (Optional) The name of the stage, so that it can be referenced elsewhere (eg for dependsOn property). 
# depends_on - (Optional) The array of stages that this stage depends on. Default is that this stage does not depend on 
# any other stage. However, since this is a deployment stage, you'll probably want to specify a build stage that
# this stage depends on.
# deploy_appcenter_enabled - (Optional) Whether this stages should be executed. Note that setting this to false won't completely
# cancel the stage, it will merely skip most of the stages. The stage will appear to complete successfully, so
# any stages that depend on this stage will attempt to execute
- name: environment_name
# artifact_name - (Optional) The name of the artifact to copy application to
# artifact_folder - (Required) The name of the folder to copy application to in the artifact
# application_package - (Required) The name of the application package to output
# appcenter_service_connection - (Required) The name of the service connection that connects Azure DevOps
# to App Center. Go to Service Connections in Azure DevOps to setup the connection and assign permissions
# for pipelines to access it
# appcenter_organisation - (Required) The organisation (or individual) in App Center that the application 
# is associated with. In AppCenter navigate to the application and extract organisation from URL
# eg https://appcenter.ms/users/[organisation]/apps/[applicationid]
# appcenter_applicationid - (Required) The application id in App Center that identifies 
# the application. In AppCenter navigate to the application and extract application id from URL
# eg https://appcenter.ms/users/[organisation]/apps/[applicationid]
# appcenter_release_notes - (Optional) The release notes to be set in App Center for the release. 
# secure_file_keystore_filename - (Optiona) IMPORTANT: This is required if application package is an AAB. 
# The keystore file used to sign the APK when extracte from an AAB. This is the name of the keystore in Secure Files. 
# keystore_alias - (Optional) IMPORTANT: This is required if application package is an AAB. The alias of the keystore. 
- name: keystore_alias
  type: string
  default: ''
# keystore_password - (Optional) IMPORTANT: This is required if application package is an AAB. The password to access the keystore
- name: keystore_password
  type: string
  default: ''

# onStart - Steps to be executed before stage starts
- name: onStart
  type: stepList
  default: []
# postArtifactDownload - Steps to be executed after artifacts from previous stages have been downloaded
- name: postArtifactDownload
  type: stepList
  default: []
# preAppCenterPublish - Steps to be executed before application package is published to App Center
- name: preAppCenterPublish
  type: stepList
  default: []
# onEnd - Steps to be executed at the end of the stage
- name: onEnd
  type: stepList
  default: []



- task: AppCenterDistribute@3
  inputs:
    serverEndpoint: 
    appSlug: 
    appFile: 
    #symbolsOption: 'Apple' # Optional. Options: apple, android
    #symbolsPath: # Optional
    #symbolsPdbFiles: '**/*.pdb' # Optional
    #symbolsDsymFiles: # Optional
    #symbolsIncludeParentDirectory: # Optional
    #releaseNotesOption: 'input' # Options: input, file
    #releaseNotesInput: # Required when releaseNotesOption == Input
    #releaseNotesFile: # Required when releaseNotesOption == File
    #isMandatory: false # Optional
    #destinationType: 'groups' # Options: groups, store
    #distributionGroupId: # Optional
    #destinationStoreId: # Required when destinationType == store
    #isSilent: # Optional
```


## Arguments

<table><thead><tr><th>Argument</th><th>Description</th></tr></thead>
<tr><td>App Center service connection</td><td>(Required) Select the service connection for App Center. Create a new App Center service connection in Azure DevOps project settings.</td></tr>
<tr><td>App slug</td><td>(Required) The app slug is in the format of <strong>{username}/{app_identifier}</strong>.  To locate <strong>{username}</strong> and <strong>{app_identifier}</strong> for an app, click on its name from <a href="https://appcenter.ms/apps" data-raw-source="https://appcenter.ms/apps">https://appcenter.ms/apps</a>, and the resulting URL is in the format of <a href="https://appcenter.ms/users/{username}/apps/{app_identifier}" data-raw-source="[https://appcenter.ms/users/&lt;b&gt;{username}&lt;/b&gt;/apps/&lt;b&gt;{app_identifier}&lt;/b&gt;](https://appcenter.ms/users/{username}/apps/{app_identifier})">https://appcenter.ms/users/<b>{username}</b>/apps/<b>{app_identifier}</b></a>. If you are using orgs, the app slug is of the format <strong>{orgname}/{app_identifier}</strong>.</td></tr>
<tr><td>Binary file path</td><td>(Required) Relative path from the repo root to the APK or IPA file you want to publish</td></tr>
<tr><td>Symbols type</td><td>(Optional) Include symbol files to receive symbolicated stack traces in App Center Diagnostics. Options: <code>Android</code>, <code>Apple</code>.</td></tr>
<tr><td>Symbols path</td><td>(Optional) Relative path from the repo root to the symbols folder.</td></tr>
<tr><td>Symbols path (*.pdb)</td><td>(Optional) Relative path from the repo root to PDB symbols files. Path may contain wildcards.</td></tr>
<tr><td>dSYM path</td><td>(Optional) Relative path from the repo root to dSYM folder. Path may contain wildcards.</td></tr>
<tr><td>Include all items in parent folder</td><td>(Optional) Upload the selected symbols file or folder and all other items inside the same parent folder. This is required for React Native apps.</td></tr>
<tr><td>Create release notes</td><td>(Required) Release notes will be attached to the release and shown to testers on the installation page. Options: <code>input</code>, <code>file</code>.</td></tr>
<tr><td>Release notes</td><td>(Required) Release notes for this version.</td></tr>
<tr><td>Release notes file</td><td>(Required) Select a UTF-8 encoded text file which contains the Release Notes for this version.</td></tr>
<tr><td>Require users to update to this release</td><td>(Optional) App Center Distribute SDK required to mandate update. Testers will automatically be prompted to update.</td></tr>
<tr><td>Release destination</td><td>(Required) Each release will be distributed to either groups or a store. Options: <code>groups</code>, <code>store</code>.</td></tr>
<tr><td>Destination IDs</td><td>(Optional) IDs of the distribution groups to release to. Leave it empty to use the default group and use commas or semicolons to separate multiple IDs.</td></tr>
<tr><td>Destination ID</td><td>(Required) ID of the distribution store to deploy to.</td></tr>
<tr><td>Do not notify testers. Release will still be available to install.</td><td>(Optional) Testers will not receive an email for new releases.</td></tr>


<tr>
<th style="text-align: center" colspan="2"><a href="~/pipelines/process/tasks.md#controloptions" data-raw-source="[Control options](../../process/tasks.md#controloptions)">Control options</a></th>
</tr>

</table>

## Example

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
```

## Open source

This task is open source [on GitHub](https://github.com/Microsoft/azure-pipelines-tasks). Feedback and contributions are welcome.
