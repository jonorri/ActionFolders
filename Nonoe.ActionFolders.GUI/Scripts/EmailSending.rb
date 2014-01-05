require 'Nonoe.ActionFolders.BusinessLogic.dll'

class Script
    attr_accessor :jsonConfigs

	# Every attr_accessor is used as a config for the script. Can be set in client.
	# SMTP server to use.
	attr_accessor :smtpServer

	# What email to send to
	attr_accessor :emailTo

	# Email from in the email to send out.
	attr_accessor :emailFrom

	# Password of the email account.
	attr_accessor :password

	# Subject of the email to send out.
	attr_accessor :subject

	# Body of the email to send out.
	attr_accessor :body
   
    #
    #  This method is the "runner" for the script.
    # 
    def Run(programPath)
		obj = Nonoe::ActionFolders::BusinessLogic::Helpers::HelperFunction.new
		obj.SendMail(@smtpServer, @emailTo, @emailFrom, @password, @subject, @body, programPath)
    end
    
    #
    #  Constructor
    #
    def initialize(jsonConfigs)
        @jsonConfigs = jsonConfigs

		# Pull out the smtp server from the json string
		@smtpServer = jsonConfigs['smtpServer']

		# Pull out the email to field from the json string
		@emailTo = jsonConfigs['emailTo']

		# Pull out the email from from the json string
		@emailFrom = jsonConfigs['emailFrom']

		# Pull out the password from the json string
		@password = jsonConfigs['password']

		# Pull out the subject from the json string
		@subject = jsonConfigs['subject']

		# Pull out the body from the json string
		@body = jsonConfigs['body']
    end
end