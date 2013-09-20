class ClassA
	def m1
	end
	def m2
	end
	def M3
	end
end
#puts ClassA.methods
puts ClassA.instance_methods false
a=ClassA.new
def ClassA.m4
end
class ClassA
	def m5 
	end
end
def a.m6
end
puts "=====ClassA.instance_methods false====="
puts ClassA.instance_methods false
puts "=====Class.instance_methods false====="
puts Class.instance_methods false
puts "=====ClassA.methods====="
puts ClassA.methods
puts "=====a.methods====="
puts a.methods
