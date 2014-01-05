require 'Nonoe.ActionFolders.BusinessLogic.dll'

class Script
    attr_accessor :jsonConfigs
	attr_accessor :smtpServer
	attr_accessor :emailTo
	attr_accessor :emailFrom
	attr_accessor :password
	attr_accessor :subject
	attr_accessor :body
   
    #
    #  This method is the "runner" for the script. It evaluates the expression from the DB.
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
		@smtpServer = jsonConfigs['smtpServer']
		@emailTo = jsonConfigs['emailTo']
		@emailFrom = jsonConfigs['emailFrom']
		@password = jsonConfigs['password']
		@subject = jsonConfigs['subject']
		@body = jsonConfigs['body']
    end
end