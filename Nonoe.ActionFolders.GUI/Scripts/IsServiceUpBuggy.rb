class Script2
    attr_accessor :jsonConfigs
	    
    #
    #  Constructor
    #
    def initialize(jsonConfigs)
        @jsonConfigs = jsonConfigs
    end
   
    #
    #  This method is the "runner" for the script.
    # 
    def Run222(programPath)
        file = File.open(programPath, "w+")
		file.puts("Yes I am up!")
		file.close()
    end
end