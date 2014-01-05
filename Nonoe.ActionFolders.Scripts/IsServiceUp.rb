class Script
    attr_accessor :jsonConfigs
   
    #
    #  This method is the "runner" for the script. It evaluates the expression from the DB.
    # 
    def Run(programPath)
        file = File.open(programPath, "w+")
		file.puts("Yes I am up!")
		file.close()
    end
    
    #
    #  Constructor
    #
    def initialize(jsonConfigs)
        @jsonConfigs = jsonConfigs
    end
end