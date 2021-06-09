pipeline {
	agent any
	
	environment {
		gitlab_user_pwd=credentials('gitlab-user-pwd')
		BuildConfiguration="Debug"
		ImageName="registry.gitlab.com/rayprosoft/turnkey-gaming-system/applepay"
	}

	stages {
		stage('Build') {
			steps {
				sh 'dotnet build -c $BuildConfiguration'
			}
		}

		stage('Test') {
			steps {
				sh 'dotnet test -c $BuildConfiguration --logger trx --no-build'
			}
		}
		
		stage('Push packages') {
			steps {
				sh 'dotnet pack -c $BuildConfiguration "Tgs.Payment.ApplePay.Client/Tgs.Payment.ApplePay.Client.csproj" --no-build'
				sh 'dotnet nuget push "Tgs.Payment.ApplePay.Client/bin/$BuildConfiguration/*.nupkg" --source "raypro" --skip-duplicate'
			}
		}

		stage('Build Docker Image') {
			steps {
				sh 'dotnet build "Tgs.Payment.ApplePay/Tgs.Payment.ApplePay.csproj" -c $BuildConfiguration -t:ContainerBuild -p:DockerfileTag="$ImageName:v${BUILD_NUMBER}" --no-restore '
			}
		}

		stage('Push Docker Image') {
			steps {
				sh 'sudo docker push $ImageName:v${BUILD_NUMBER}'
			}
		}

		stage('Deploy to dev') {
			input {
				message 'Ready to go?'
				ok 'yes'
			}

			steps {
				configFileProvider([
					configFile(
						fileId: 'applepay.dev.json', 
						variable: 'applepaydev')]) {
					script {
						def json = readJSON file: "$applepaydev";

						env.TGS = json.tgs;
						env.PaymentApiUrl = json.paymentApiUrl;
						env.NatsUri = json.nats;
						env.CallbackUrl = json.callbackBaseUrl;

						withKubeConfig([credentialsId: 'k8s-kube-config', serverUrl: 'https://192.168.50.105:6443']) {
							sh '''
								helm template k8s/applepay \
									--set image.tag=v${BUILD_NUMBER} \
									--set namespace=dev \
									--set "connectionStrings.tgs=${TGS}" \
									--set paymentApiUrl=${PaymentApiUrl} \
									--set nats=${NatsUri} \
									--set callbackBaseUrl=${CallbackUrl}
							'''
							sh '''
								helm template k8s/applepay \
									--set image.tag=v${BUILD_NUMBER} \
									--set namespace=dev \
									--set "connectionStrings.tgs=${TGS}" \
									--set paymentApiUrl=${PaymentApiUrl} \
									--set nats=${NatsUri} \
									--set callbackBaseUrl=${CallbackUrl} | kubectl -n dev apply -f -
							'''
						}
					}
				}
			}
		}
	}

	post {
		always {
			step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: false, keepLongStdio: true])
		}
	}
}