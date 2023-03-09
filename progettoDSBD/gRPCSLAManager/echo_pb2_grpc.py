# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import echo_pb2 as echo__pb2


class EchoServiceStub(object):
    """Missing associated documentation comment in .proto file."""

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.takeAllMetrics = channel.unary_unary(
                '/echo.EchoService/takeAllMetrics',
                request_serializer=echo__pb2.Request.SerializeToString,
                response_deserializer=echo__pb2.Reply.FromString,
                )
        self.takeDefaultRangedValue = channel.unary_unary(
                '/echo.EchoService/takeDefaultRangedValue',
                request_serializer=echo__pb2.Request.SerializeToString,
                response_deserializer=echo__pb2.Reply.FromString,
                )
        self.callETLDataPipeline = channel.unary_unary(
                '/echo.EchoService/callETLDataPipeline',
                request_serializer=echo__pb2.Request.SerializeToString,
                response_deserializer=echo__pb2.Reply.FromString,
                )
        self.getViolationsForSLAManager = channel.unary_unary(
                '/echo.EchoService/getViolationsForSLAManager',
                request_serializer=echo__pb2.Request.SerializeToString,
                response_deserializer=echo__pb2.Reply.FromString,
                )
        self.getFutureViolationsForSLAManager = channel.unary_unary(
                '/echo.EchoService/getFutureViolationsForSLAManager',
                request_serializer=echo__pb2.Request.SerializeToString,
                response_deserializer=echo__pb2.Reply.FromString,
                )


class EchoServiceServicer(object):
    """Missing associated documentation comment in .proto file."""

    def takeAllMetrics(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def takeDefaultRangedValue(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def callETLDataPipeline(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def getViolationsForSLAManager(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def getFutureViolationsForSLAManager(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_EchoServiceServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'takeAllMetrics': grpc.unary_unary_rpc_method_handler(
                    servicer.takeAllMetrics,
                    request_deserializer=echo__pb2.Request.FromString,
                    response_serializer=echo__pb2.Reply.SerializeToString,
            ),
            'takeDefaultRangedValue': grpc.unary_unary_rpc_method_handler(
                    servicer.takeDefaultRangedValue,
                    request_deserializer=echo__pb2.Request.FromString,
                    response_serializer=echo__pb2.Reply.SerializeToString,
            ),
            'callETLDataPipeline': grpc.unary_unary_rpc_method_handler(
                    servicer.callETLDataPipeline,
                    request_deserializer=echo__pb2.Request.FromString,
                    response_serializer=echo__pb2.Reply.SerializeToString,
            ),
            'getViolationsForSLAManager': grpc.unary_unary_rpc_method_handler(
                    servicer.getViolationsForSLAManager,
                    request_deserializer=echo__pb2.Request.FromString,
                    response_serializer=echo__pb2.Reply.SerializeToString,
            ),
            'getFutureViolationsForSLAManager': grpc.unary_unary_rpc_method_handler(
                    servicer.getFutureViolationsForSLAManager,
                    request_deserializer=echo__pb2.Request.FromString,
                    response_serializer=echo__pb2.Reply.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'echo.EchoService', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class EchoService(object):
    """Missing associated documentation comment in .proto file."""

    @staticmethod
    def takeAllMetrics(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/echo.EchoService/takeAllMetrics',
            echo__pb2.Request.SerializeToString,
            echo__pb2.Reply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def takeDefaultRangedValue(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/echo.EchoService/takeDefaultRangedValue',
            echo__pb2.Request.SerializeToString,
            echo__pb2.Reply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def callETLDataPipeline(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/echo.EchoService/callETLDataPipeline',
            echo__pb2.Request.SerializeToString,
            echo__pb2.Reply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def getViolationsForSLAManager(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/echo.EchoService/getViolationsForSLAManager',
            echo__pb2.Request.SerializeToString,
            echo__pb2.Reply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def getFutureViolationsForSLAManager(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/echo.EchoService/getFutureViolationsForSLAManager',
            echo__pb2.Request.SerializeToString,
            echo__pb2.Reply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)