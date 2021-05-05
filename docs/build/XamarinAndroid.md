---
title: Xamarin Android Build Template
description: Template for building a Xamarin Android application
author: Nick Randolph
---

# Xamarin Android Build Template

Use this template to build Android applications from a Visual Studio Solution file (ie Xamarin).

## YAML snippet

```yaml
# Xamarin Android Build Template
# Template for building a Xamarin Android application
stages:
- template:  azure/mobile/build-xamarin-android.yml@builttoroam_templates
  parameters:
    solution_filename:
    secure_file_keystore_filename:
    keystore_alias:
    keystore_password:
    #stage_name:  # Optional 
    #depends_on:  # Optional 
    #build_android_enabled:  # Optional 
    #build_number:  # Optional 
    #full_version_number:  # Optional 
    #solution_build_configuration:  # Optional 
    #solution_target_platform:  # Optional 
    #android_manifest_filename:  # Optional 
    #artifact_name:  # Optional 
    #artifact_folder:  # Optional 
    #application_package:  # Optional 
    #onStart:  # Optional 
    #preBuild:  # Optional 
    #postBuild:  # Optional 
    #prePublish:  # Optional 
    #onEnd:  # Optional 
    #android_nuget_version:  # Optional 
    #net_core_version:  # Optional 
```


## Arguments

<table><thead><tr><th>Argument</th><th>Description</th></tr></thead>
<tr><td>stage_name</td><td>(Optional) The name of the stage, so that it can be referenced elsewhere (eg for dependsOn property). Defaults to 'Build_Android'</td></tr>
<tr><td>depends_on</td><td>(Optional) The array of stages that this stage depends on. Default is that this stage does not depend on any other stage</td></tr>
<tr><td>build_android_enabled</td><td>(Optional) Whether this stages should be executed. Note that setting this to false won't completely cancel the stage, it will merely skip most of the stages. The stage will appear to complete successfully, so any stages that depend on this stage will attempt to execute</td></tr>
<tr><td>build_number</td><td>(Optional) The build number to be applied to the application. Defaults to Build.BuildId built in variable</td></tr>
<tr><td>full_version_number</td><td>(Optional) The full application version number. Defaults to 1.0.XXX where XXX is the same as the build_number</td></tr>
<tr><td>solution_filename</td><td>(Required) The relative path to the solution file that should be built</td></tr>
<tr><td>solution_build_configuration</td><td>(Optional) The build configuration within the solution that should be invoked. Default is Release but can be overwritten if you want to do say a Debug build</td></tr>
<tr><td>solution_target_platform</td><td>(Optional) The target platform that the solution build will use. Defaults to Any CPU</td></tr>
<tr><td>android_manifest_filename</td><td>(Optional) The relative path to the AndroidManifest.xml file that defines the application manifest. If not specified, template will search for AndroidManifest.xml file</td></tr>
<tr><td>secure_file_keystore_filename</td><td>(Required) The keystore file used to sign the application. This is the name of the keystore in Secure Files</td></tr>
<tr><td>keystore_alias</td><td>(Required) The alias of the keystore. </td></tr>
<tr><td>keystore_password</td><td>(Required) The password to access the keystore</td></tr>
<tr><td>artifact_name</td><td>(Optional) The name of the artifact to copy application to</td></tr>
<tr><td>artifact_folder</td><td>(Optional) The name of the folder to copy application to in the artifact</td></tr>
<tr><td>application_package</td><td>(Optional) The name of the application package to output</td></tr>
<tr><td>onStart</td><td>Steps to be executed before stage starts</td></tr>
<tr><td>preBuild</td><td>Steps to be executed before the build starts</td></tr>
<tr><td>postBuild</td><td>Steps to be executed after the build has been invoked</td></tr>
<tr><td>prePublish</td><td>Steps to be executed before application package is published to artifact</td></tr>
<tr><td>onEnd</td><td>Steps to be executed at the end of the stage</td></tr>
<tr><td>android_nuget_version</td><td>(Optional) Use to override the NuGet version (defaults to 5.6.0)</td></tr>
<tr><td>net_core_version</td><td>(Optional) Use to override the .NET Core version (defaults to 3.0.x)</td></tr>


</table>

## Open source

This template is open source [on GitHub](https://github.com/builttoroam/pipeline_templates). Feedback and contributions are welcome.
