# This script checks whether the ActionFolder service is up on the machine or not.
# If it is then it inputs into the txt file the phrase "Yes I am up!"

class Script
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
    def Run(programPath)
        file = File.open(programPath, "w+")
		file.puts("Yes I am up!")
		file.close()
    end
end